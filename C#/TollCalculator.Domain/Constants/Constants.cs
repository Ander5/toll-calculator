using TollCalculator.Domain.Enums;

namespace TollCalculator.Domain.Constants;
public class Constants
{
    /**
        * <summary> The vehicles that are exempt from toll. </summary>
    */
    public static VehicleType[] TollfreeVehicles => [
        VehicleType.TRACTOR, 
        VehicleType.EMERGENCY, 
        VehicleType.DIPLOMAT, 
        VehicleType.FOREIGN, 
        VehicleType.MILITARY,
        VehicleType.MOTORBIKE,
        VehicleType.UNKNOWN,
    ];

    /**
        * <summary> An array of timespans and the corresponding toll value, where the timespan indicates time of the day where toll rates are changed. </summary>
    */
    public static (TimeSpan Time, decimal Toll)[] Tolls = 
    [
        (Time: TimeSpan.Zero, Toll: 0),
        (Time: new TimeSpan(6, 0, 0), Toll: 8m),
        (Time: new TimeSpan(6, 30, 0), Toll: 13m),
        (Time: new TimeSpan(7, 0, 0), Toll: 18m),
        (Time: new TimeSpan(8, 0, 0), Toll: 13m),
        (Time: new TimeSpan(8, 30, 0), Toll: 8m),
        (Time: new TimeSpan(15, 0, 0), Toll: 13m),
        (Time: new TimeSpan(15, 30, 0), Toll: 18m),
        (Time: new TimeSpan(17, 0, 0), Toll: 13m),
        (Time: new TimeSpan(18, 0, 0), Toll: 8m),
        (Time: new TimeSpan(18, 30, 0), Toll: 0m),
    ];

    /**
        * <summary> Time span of which toll passages are merged and the highest one used. </summary>
    */
    public static TimeSpan TollSpan => TimeSpan.FromHours(1);

    /**
        * <summary> The max toll per run. </summary>
    */
    public static decimal MaxToll => 60m;
}
