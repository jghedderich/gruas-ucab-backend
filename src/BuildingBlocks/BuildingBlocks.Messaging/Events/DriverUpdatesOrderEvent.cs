namespace BuildingBlocks.Messaging.Events
{
    public record DriverUpdatesOrderEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; } = default!;
        public string Status { get; set; } = default!; 
    }
}
