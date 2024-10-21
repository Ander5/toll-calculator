namespace TollCalculator.Services.DateTimeService;

public interface IDateTimeService
{
    /**
        * <summary> Checks if a provided date is toll free</summary>
        * <param name="date"> The date to check </param>
        * <returns> A boolean indicating if the provided date was toll free</returns>
    */
    public bool IsTollFreeDate(DateTime date);

    /**
        * <summary> Groups the provided datetimes into separate "bins" based on a provided timespan</summary>
        * <param name="dates"/> The dates to bin </param>
        * <param name="span"/> The timespan of within to bin </param>
        * <returns> A list of bins, where each bin contains the dates within <paramref name="span"/> of the lowest date. </returns>
    */
    public IEnumerable<IEnumerable<DateTime>> BinDatesByTime(IEnumerable<DateTime> dates, TimeSpan span);
}
