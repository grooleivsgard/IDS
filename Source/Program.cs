// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using RaaLabs.Edge.Modules.EventHandling;
using RaaLabs.Edge.Modules.EdgeHub;
using RaaLabs.Edge.Modules.Configuration;
using RaaLabs.Edge.Modules.Timescaledb;

namespace RaaLabs.Edge.IntrusionDetectionSystem
{
    static class Program
    {
        static void Main(string[] args)
        {
            var applicationBuilder = new ApplicationBuilder()
                .WithModule<EventHandling>()
                .WithModule<Configuration>()
                .WithModule<Timescaledb>()
                .WithTask<DbReadEventProducer>()
                .WithHandler<Connection3Consumer>()
                .WithTask<MetricsCollector>();
            
            var application = applicationBuilder.Build();

            application.Run().Wait();
        }
    }
}