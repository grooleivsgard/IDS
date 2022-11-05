using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RaaLabs.Edge.IntrusionDetectionSystem.Events;
using RaaLabs.Edge.Modules.EventHandling.RequestHandling;
using RaaLabs.Edge.Modules.Timescaledb;

namespace RaaLabs.Edge.IntrusionDetectionSystem.Connections;

[TimescaledbConnection(typeof(PostgresConnection))]
public interface IPostgresClient : IRequestClient<TimescaleDbRequestKind>
{
    [Query("SELECT * from connection3 WHERE bytes_in = @requestedBytes")]
    public Task<IEnumerable<DbDatapointOutput>> GetDataByRequestedBytes(long requestedBytes);

}