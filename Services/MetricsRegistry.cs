using App.Metrics;
using App.Metrics.Counter;

namespace Domain;

public class MetricsRegistry
{
    /*private static CounterOptions SongsCounter (string name) => new CounterOptions
    {
        Name = name,
        Context = "SongsApi",
        MeasurementUnit = Unit.Calls
    };*/

    public static CounterOptions CreatedSongsCounter => new CounterOptions
    {
        Name = "Created Songs",
        Context = "SongsApi",
        MeasurementUnit = Unit.Calls
    };
    public static CounterOptions DeletedSongsCounter => new CounterOptions
    {
        Name = "Deleted Songs",
        Context = "SongsApi",
        MeasurementUnit = Unit.Calls
    };
    
    public static CounterOptions UpdatedSongsCounter => new CounterOptions
    {
        Name = "Updated Songs",
        Context = "SongsApi",
        MeasurementUnit = Unit.Calls
    };
    
    public static CounterOptions ReadSongsCounter => new CounterOptions
    {
        Name = "Read Songs",
        Context = "SongsApi",
        MeasurementUnit = Unit.Calls
    };
}