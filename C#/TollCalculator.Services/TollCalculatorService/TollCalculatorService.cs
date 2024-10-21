using TollCalculator.Domain.Constants;
using TollCalculator.Domain.Enums;

namespace TollCalculator.Services.TollCalculatorService;

public class TollCalculatorService : ITollCalculatorService
{
    /// <inheritdoc />
    public bool IsTollFreeVehicle(VehicleType vehicle)
    {
        return Constants
            .TollfreeVehicles
            .Contains(vehicle);
    }

    /// <inheritdoc />
    public decimal GetTollFee(DateTime date) {
        TimeSpan timeOfDay = new TimeSpan(date.Hour, date.Minute, date.Second);
        return Constants
            .Tolls
            .TakeWhile(timeAndFee => timeOfDay >= timeAndFee.Time)
            .LastOrDefault()
            .Toll;
    }
}
