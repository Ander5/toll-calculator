using TollCalculator.App;
using TollCalculator.Domain.Enums;

if(args.Count() < 4) {
    Console.WriteLine( @"

Usage: TollCalculator.exe [options]

Options:
    --vehicle   The Vehicle to use, one of car | motorbike | tractor | emergency | diplomat | foreign | military
    --dates    comma-separated list of dates in the format ""yyyy-MM-dd HH:mm:ss""
        
Example: 
    TollCalculator.App.exe --vehicle car --dates ""2024-10-21 06:50:30,2024-10-21 07:50:30,,2024-10-21 17:50:30""
");
    return 0;
}

// App inputs
VehicleType vehicle = VehicleType.UNKNOWN;
DateTime[] dates = [];

// Parse and assign args
foreach(var arg in args.Select((value, i) => (i, value))) 
{
    if(arg.value == "--vehicle") 
    {
        vehicle = (VehicleType) Enum.Parse(typeof(VehicleType), args[arg.i+1].ToUpper());
    }
    else if(arg.value == "--dates") 
    {
        dates = args[arg.i+1]
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .Select(date => DateTime.Parse(date)).ToArray();
    }
}

// Run
var app = new TollCalculatorApp();
decimal result = app.GetTollFeeForDates(vehicle, dates);

// Write result
Console.WriteLine(result);

return 0;