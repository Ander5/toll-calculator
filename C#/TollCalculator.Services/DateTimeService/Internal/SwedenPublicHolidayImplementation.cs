
using PublicHoliday;

namespace TollCalculator.Services.DateTimeService.Internal;

internal class SwedenPublicHolidayImplementation : IHolidayService
{
    private SwedenPublicHoliday holidaysService => new SwedenPublicHoliday();

    /// <inheritdoc />
    public bool IsHoliday(DateTime date)
    {
        return holidaysService.IsPublicHoliday(date);
    }

    /// <inheritdoc />
    public bool IsWorkingDay(DateTime date)
    {
        return holidaysService.IsWorkingDay(date);
    }
}
