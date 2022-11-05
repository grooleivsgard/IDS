using System.Threading.Tasks;
using RaaLabs.Edge.IntrusionDetectionSystem.Events;
using RaaLabs.Edge.Modules.EventHandling;
using Serilog;

namespace RaaLabs.Edge.IntrusionDetectionSystem;

public class Connection3Consumer : IConsumeEvent<InternalEvent>
{
    private ILogger _logger;

    public Connection3Consumer(ILogger logger)
    {
        _logger = logger;
    }

    public void Handle(InternalEvent @event)
    {
        _logger.Information("{BytesIn}, {BytesOut}", @event.bytes_in, @event.bytes_out);
    }
}