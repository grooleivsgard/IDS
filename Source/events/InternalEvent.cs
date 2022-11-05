// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

using RaaLabs.Edge.IntrusionDetectionSystem.Connections;
using RaaLabs.Edge.Modules.EventHandling;
using RaaLabs.Edge.Modules.Timescaledb;


namespace RaaLabs.Edge.IntrusionDetectionSystem.Events;

public class InternalEvent : IEvent
{
    public long bytes_in { get; set; }
    public long bytes_out { get; set; }
    public long timestamp { get; set; }
}
