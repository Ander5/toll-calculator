
using TollCalculator.Domain.Constants;
using TollCalculator.Services.DateTimeService;

namespace TollCalculator.Tests;

public class TestData_IsTollFreeDate_HolidaysAndWeekends : TheoryData<DateTime> {
    public TestData_IsTollFreeDate_HolidaysAndWeekends() {

        // Holidays
        Add(new DateTime(2024, 12, 24));
        Add(new DateTime(2024, 12, 25));
        Add(new DateTime(2024, 12, 26));
        Add(new DateTime(2024, 12, 31));
        Add(new DateTime(2024, 12, 31));
        Add(new DateTime(2025, 12, 31));
        Add(new DateTime(2026, 12, 31));
        Add(new DateTime(2027, 12, 31));
        Add(new DateTime(2025, 01, 06));
        Add(new DateTime(2025, 04, 18));
        Add(new DateTime(2025, 04, 20));
        Add(new DateTime(2025, 05, 29));
        Add(new DateTime(2025, 06, 06));
        Add(new DateTime(2025, 06, 21));

        // Some weekends
        Add(new DateTime(2025, 03, 15));
        Add(new DateTime(2025, 03, 16));
        Add(new DateTime(2024, 10, 20));
    }
}

public class TestData_IsTollFreeDate_Weekdays : TheoryData<DateTime> {
    public TestData_IsTollFreeDate_Weekdays() {
        Add(new DateTime(2024, 12, 9));
        Add(new DateTime(2024, 12, 10));
        Add(new DateTime(2024, 12, 11));
    }
}

public class TestData_BinDatesByTime : TheoryData<DateTime[], IEnumerable<IEnumerable<DateTime>>> {
    public TestData_BinDatesByTime() {
        
        var dates = new DateTime[] {
            new DateTime(2024, 12, 9, 8, 30, 23),
            new DateTime(2024, 12, 9, 8, 31, 1),
            new DateTime(2024, 12, 9, 9, 29, 2),
            new DateTime(2024, 12, 9, 11, 30, 23),
        };

        var expected = new List<IEnumerable<DateTime>>() 
        {
            new List<DateTime>() 
            {
                dates[0],
                dates[1],
                dates[2],
            },
            new List<DateTime>() 
            {
                dates[4],
            }
         };
    }
}

public class DateTimeServiceTests
{
    [Theory]
    [ClassData(typeof(TestData_IsTollFreeDate_HolidaysAndWeekends))]
    public void IsTollFreeDate_IsHolidayOrWeekend_ReturnsTrue(DateTime value) {
        // Arrange
        var sut = new DateTimeService();

        // Act
        var result = sut.IsTollFreeDate(value);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [ClassData(typeof(TestData_IsTollFreeDate_Weekdays))]
    public void IsTollFreeDate_IsWeekday_ReturnsFalse(DateTime value) {
        // Arrange
        var sut = new DateTimeService();

        // Act
        var result = sut.IsTollFreeDate(value);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void BinDatesByTime_Dataset1_ReturnsCorrectBins() {
        // Arrange
        var sut = new DateTimeService();
        var dates = new DateTime[] {
            new DateTime(2024, 12, 9, 8, 30, 23),
            new DateTime(2024, 12, 9, 8, 31, 1),
            new DateTime(2024, 12, 9, 9, 29, 2),
            new DateTime(2024, 12, 9, 11, 30, 23),
        };

        // Act
        var result = sut.BinDatesByTime(dates, Constants.TollSpan);
        
        // Assert
        var resultAsArray = result.ToArray();
        Assert.Equal(2, resultAsArray.Count());
        Assert.True(resultAsArray[0].Count() == 3);
        Assert.True(resultAsArray[1].Count() == 1);
        Assert.Contains(dates[0], resultAsArray[0]);
        Assert.Contains(dates[1], resultAsArray[0]);
        Assert.Contains(dates[2], resultAsArray[0]);
        Assert.Contains(dates[3], resultAsArray[1]);
    }

    [Fact]
    public void BinDatesByTime_Dataset2_ReturnsCorrectBins() {
        // Arrange
        var sut = new DateTimeService();
        var dates = new DateTime[] {
            new DateTime(2024, 12, 9, 8, 30, 0),
            new DateTime(2024, 12, 9, 9, 31, 0),
            new DateTime(2024, 12, 9, 11, 29, 0),
            new DateTime(2024, 12, 9, 18, 30, 0),
        };

        // Act
        var result = sut.BinDatesByTime(dates, Constants.TollSpan);
        
        // Assert
        var resultAsArray = result.ToArray();
        Assert.Equal(4, resultAsArray.Count());
        foreach(var bin in resultAsArray) {
            Assert.Single(bin);
        }
    }

    [Fact]
    public void BinDatesByTime_EdgeCase1_ReturnsCorrectBins() {
        // Arrange
        var sut = new DateTimeService();
        var dates = new DateTime[] {
            new DateTime(2024, 11, 24, 8, 30, 0),
            new DateTime(2024, 11, 24, 9, 30, 0),
            new DateTime(2024, 11, 24, 10, 30, 0),
            new DateTime(2024, 11, 24, 11, 29, 59),
        };

        // Act
        var result = sut.BinDatesByTime(dates, Constants.TollSpan);
        
        // Assert
        var resultAsArray = result.ToArray();
        Assert.Equal(3, resultAsArray.Count());
        Assert.Contains(dates[0], resultAsArray[0]);
        Assert.Contains(dates[1], resultAsArray[1]);
        Assert.Contains(dates[2], resultAsArray[2]);
        Assert.Contains(dates[3], resultAsArray[2]);
    }

    [Fact]
    public void BinDatesByTime_EdgeCase2_ReturnsCorrectBins() {
        // Arrange
        var sut = new DateTimeService();
        var dates = new DateTime[] {
            DateTime.MinValue,
            new DateTime(2024, 11, 24, 10, 30, 0),
        };

        // Act
        var result = sut.BinDatesByTime(dates, Constants.TollSpan);
        
        // Assert
        var resultAsArray = result.ToArray();
        Assert.Equal(2, resultAsArray.Count());
        Assert.Contains(dates[0], resultAsArray[0]);
        Assert.Contains(dates[1], resultAsArray[1]);
    }
}
