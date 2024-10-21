using TollCalculator.Services.DateTimeService.Internal;

namespace TollCalculator.Services.DateTimeService;

public class DateTimeService : IDateTimeService
{
    private IHolidayService holidaysService => new SwedenPublicHolidayImplementation();

    /// <inheritdoc />
    public bool IsTollFreeDate(DateTime date) {
        return 
            ! holidaysService.IsWorkingDay(date) 
            || holidaysService.IsHoliday(date);
    }

    /// <inheritdoc />
    public IEnumerable<IEnumerable<DateTime>> BinDatesByTime(IEnumerable<DateTime> dates, TimeSpan span) {
        var datesOrdered = dates.Order().ToList();

        while (datesOrdered.Count > 0) {
            // Take lowest date 
            DateTime current = datesOrdered.First();
            
            var currentBin = new List<DateTime>();

            // Add all dates within the provided timespan
            currentBin.AddRange(datesOrdered.TakeWhile(d => d < current.Add(span)));

            // Remove above dates from the remaining ones
            datesOrdered.RemoveAll(date => currentBin.Contains(date));

            yield return currentBin;
        }
    }
}
