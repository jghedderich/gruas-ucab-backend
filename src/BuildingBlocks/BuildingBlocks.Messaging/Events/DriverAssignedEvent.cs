

namespace BuildingBlocks.Messaging.Events;

public record DriverAssignedEvent : IntegrationEvent
{
    public Guid OrderId { get; set; } = default!;
    public Guid DriverId { get; set; } = default!;
}

