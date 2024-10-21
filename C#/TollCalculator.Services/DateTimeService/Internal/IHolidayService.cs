using System;

namespace TollCalculator.Services.DateTimeService.Internal;

internal interface IHolidayService
{

    /**
        * <summary> Checks if a provided date is a working day. </summary>
        * <param name="date"> The date to check </param>
        * <returns> A boolean indicating if the provided vehicle is a working day. </returns>
    */
    public bool IsWorkingDay(DateTime date);

    /**
        * <summary> Checks if a provided date is a holiday. </summary>
        * <param name="date"> The date to check. </param>
        * <returns> A boolean indicating if the provided vehicle is a holiday. </returns>
    */
    public bool IsHoliday(DateTime date);
}
