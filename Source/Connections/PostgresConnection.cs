using System;
using RaaLabs.Edge.Modules.Timescaledb;

namespace RaaLabs.Edge.IntrusionDetectionSystem.Connections;

public class PostgresConnection : ITimescaledbConnection
{
    public string ConnectionString { get; set; }

    public PostgresConnection()
    {
        ConnectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION") ?? "Server=localhost;Port=5432;Username=postgres;Password=87654321;Database=TimeseriesDB";
    }
}