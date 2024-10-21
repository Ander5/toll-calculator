using TollCalculator.Domain.Constants;
using TollCalculator.Domain.Enums;
using TollCalculator.Services.DateTimeService;
using TollCalculator.Services.TollCalculatorService;

namespace TollCalculator.App {
    public class TollCalculatorApp
    {
        private ITollCalculatorService tollService => new TollCalculatorService();
        private IDateTimeService dateTimeService => new DateTimeService();

        /**
            * <summary>Calculate the total toll fee for one day</summary>
            * <param name="vehicle">@param vehicle - the vehicle</param>
            * <param name="dates">@param vehicle - the dates</param>
            * <returns> The total toll fee for that day </returns>
        */
        public decimal GetTollFeeForDates(VehicleType vehicle, DateTime[] dates)
        {
            // Don't need to proceed if vehicle is toll free
            if(tollService.IsTollFreeVehicle(vehicle)) {
                return 0.0M;
            }

            // Only use dates with tolls
            var nonFreeDates = dates
                .Where(date => !dateTimeService.IsTollFreeDate(date)
            );

            // Calculate sum
            decimal sum = 
                dateTimeService.BinDatesByTime(
                    dates.Where(date => !dateTimeService.IsTollFreeDate(date)),
                    Constants.TollSpan
                )
                .Select(
                    bin => bin.Select(date => (
                        Date: date, 
                        Fee: tollService.GetTollFee(date)
                    )))
                .Select(span => span.Max(d => d.Fee))
                .Sum();
                    
            // Don't return more than Constants.MaxToll
            return Math.Min(sum, Constants.MaxToll);
        }
    }
}