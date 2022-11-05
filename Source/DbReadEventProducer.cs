using System.Threading.Tasks;
using RaaLabs.Edge.IntrusionDetectionSystem.Connections;
using RaaLabs.Edge.IntrusionDetectionSystem.Events;
using RaaLabs.Edge.Modules.EventHandling;
using Serilog;
using ZSpitz.Util;

namespace RaaLabs.Edge.IntrusionDetectionSystem;

public class DbReadEventProducer : IRunAsync, IProduceEvent<InternalEvent>
{
    private readonly IPostgresClient _client;
    private readonly ILogger _logger;
    public event AsyncEventEmitter<InternalEvent> SendEvent;
    
    public DbReadEventProducer(IPostgresClient client, ILogger logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task Run()
    {
        while (true)
        {
            
        var data = await _client.GetDataByRequestedBytes(10);
        _logger.Information("fetching data");

        foreach (var dataPoint in data)
        {
            var outgoingDataPoint = new InternalEvent()
            {
                bytes_in = dataPoint.bytes_in,
                bytes_out = dataPoint.bytes_out,
                timestamp = dataPoint.timestamp,
            };
            await SendEvent!(outgoingDataPoint);

        }
        await Task.Delay(5000);
        }

    }
}