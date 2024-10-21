using TollCalculator.Domain.Constants;
using TollCalculator.Domain.Enums;
using TollCalculator.Services.TollCalculatorService;

namespace TollCalculator.Tests;

public class TestData_GetTollFee_SingleTollDates : TheoryData<DateTime, decimal> {

    public TestData_GetTollFee_SingleTollDates() {
        Add(new DateTime(2024, 10, 23, 8, 2, 2), 13m);
        Add(new DateTime(2024, 10, 23, 19, 2, 2), 0m);
        Add(new DateTime(2024, 10, 23, 1, 2, 2), 0m);
        Add(new DateTime(2024, 10, 21, 6, 42, 52), 13m);
        Add(new DateTime(2024, 10, 21, 6, 0, 52), 8m);

        // While we're at it, test each interval 
        foreach(var d in Constants.Tolls) {
            Add(DateTime.MinValue.Add(d.Time), d.Toll);
        }
    }
}

public class TollCalculatorServiceTests
{
    [Theory]
    [InlineData(VehicleType.DIPLOMAT)]
    [InlineData(VehicleType.EMERGENCY)]
    [InlineData(VehicleType.TRACTOR)]
    [InlineData(VehicleType.MOTORBIKE)]
    [InlineData(VehicleType.MILITARY)]
    public void IsTollFreeVehicle_IsTollFree_ReturnsTrue(VehicleType value) {
        // Arrange
        var sut = new TollCalculatorService();

        // Act
        var res = sut.IsTollFreeVehicle(value);

        // Assert
        Assert.True(res);
    }

    [Theory]
    [InlineData(VehicleType.CAR)]
    public void IsTollFreeVehicle_IsNotTollFree_ReturnsFalse(VehicleType value) {
        // Arrange
        var sut = new TollCalculatorService();

        // Act
        var res = sut.IsTollFreeVehicle(value);

        // Assert
        Assert.False(res);
    }

    [Theory]
    [ClassData(typeof(TestData_GetTollFee_SingleTollDates))]
    public void GetTollFee_ReturnsExpectedResult(DateTime date, decimal expectedToll)  {
        // Arrange
        var sut = new TollCalculatorService();

        // Act
        var toll = sut.GetTollFee(date);

        // Assert
        Assert.Equal(toll, expectedToll);
    }
}
