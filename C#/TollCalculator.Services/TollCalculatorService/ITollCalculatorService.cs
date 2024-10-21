using TollCalculator.Domain.Enums;

namespace TollCalculator.Services.TollCalculatorService;

public interface ITollCalculatorService
{
    /**
        * <summary> Checks if a provided vehicle is toll free</summary>
        * <param name="vehicle"> The vehicle to check </param>
        * <returns> A boolean indicating if the provided vehicle is toll free</returns>
    */
    public bool IsTollFreeVehicle(VehicleType vehicle);

    /**
        * <summary> Gets the toll fee for a specified time</summary>
        * <param name="date"> The time to check </param>
        * <returns> A decimal equal to the toll fee at the specified time</returns>
    */
    public decimal GetTollFee(DateTime date);
}
