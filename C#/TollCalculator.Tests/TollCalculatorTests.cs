
using TollCalculator.App;
using TollCalculator.Domain.Enums;

namespace TollCalculator.Tests;

public class TestData_GetTollFeeForDates_DatesAndExpectedFee : TheoryData<VehicleType, DateTime[], decimal> {

    public TestData_GetTollFeeForDates_DatesAndExpectedFee() {

        // Simple weekday case
        Add(
            VehicleType.CAR,
            [
                new DateTime(2024, 11, 25, 8, 30, 0),
                new DateTime(2024, 11, 25, 9, 30, 0),
                new DateTime(2024, 11, 25, 10, 30, 0),
                new DateTime(2024, 11, 25, 11, 29, 59),
            ],
            24m
        );

        // Simple weekdend case
        Add(
            VehicleType.CAR,
            [
                new DateTime(2024, 11, 24, 8, 30, 0),
                new DateTime(2024, 11, 24, 9, 30, 0),
                new DateTime(2024, 11, 24, 10, 30, 0),
                new DateTime(2024, 11, 24, 11, 29, 59),
            ],
            0m
        );

        // Toll free vehicles
        Add(VehicleType.DIPLOMAT, [new DateTime(2024, 11, 25, 8, 30, 0),], 0m);
        Add(VehicleType.EMERGENCY, [new DateTime(2024, 11, 25, 8, 30, 0),], 0m);
        Add(VehicleType.FOREIGN, [new DateTime(2024, 11, 25, 8, 30, 0),], 0m);
        Add(VehicleType.MILITARY, [new DateTime(2024, 11, 25, 8, 30, 0),], 0m);
        Add(VehicleType.MOTORBIKE, [new DateTime(2024, 11, 25, 8, 30, 0),], 0m);
        Add(VehicleType.TRACTOR, [new DateTime(2024, 11, 25, 8, 30, 0),], 0m);

        // Max fee
        Add(
            VehicleType.CAR,
            [
                new DateTime(2025, 5, 14, 6, 5, 0),
                new DateTime(2025, 5, 14, 7, 5, 0),
                new DateTime(2025, 5, 14, 8, 5, 0),
                new DateTime(2025, 5, 14, 9, 5, 0),
                new DateTime(2025, 5, 14, 10, 5, 0),
                new DateTime(2025, 5, 14, 11, 5, 0),
                new DateTime(2025, 5, 14, 12, 5, 0),
                new DateTime(2025, 5, 14, 13, 5, 0),
                new DateTime(2025, 5, 14, 14, 5, 0),
                new DateTime(2025, 5, 14, 15, 5, 0),
                new DateTime(2025, 5, 14, 16, 5, 0),
                new DateTime(2025, 5, 14, 17, 5, 0),
                new DateTime(2025, 5, 14, 18, 5, 0),
                new DateTime(2025, 5, 14, 19, 5, 0),
            ],
            60m
        );

        // Holiday
        Add(
            VehicleType.CAR,
            [
                new DateTime(2025, 5, 1, 6, 5, 0),
                new DateTime(2025, 5, 1, 7, 5, 0),
                new DateTime(2025, 5, 1, 8, 5, 0),
                new DateTime(2025, 5, 1, 9, 5, 0),
                new DateTime(2025, 5, 1, 10, 5, 0),
                new DateTime(2025, 5, 1, 11, 5, 0),
                new DateTime(2025, 5, 1, 12, 5, 0),
                new DateTime(2025, 5, 1, 13, 5, 0),
                new DateTime(2025, 5, 1, 14, 5, 0),
                new DateTime(2025, 5, 1, 15, 5, 0),
                new DateTime(2025, 5, 1, 16, 5, 0),
                new DateTime(2025, 5, 1, 17, 5, 0),
                new DateTime(2025, 5, 1, 18, 5, 0),
                new DateTime(2025, 5, 1, 19, 5, 0),
            ],
            0m
        );
    }
}

public class TollCalculatorTests
{
    [Theory]
    [ClassData(typeof(TestData_GetTollFeeForDates_DatesAndExpectedFee))]
    public void GetTollFeeForDates_ReturnsExpectedFee(VehicleType vehicle, DateTime[] dates,decimal expectedToll) {
        // Arrange
        var sut = new TollCalculatorApp();

        // Act
        decimal result = sut.GetTollFeeForDates(vehicle, dates);

        // Assert
        Assert.Equal(expectedToll, result);
    }
}
