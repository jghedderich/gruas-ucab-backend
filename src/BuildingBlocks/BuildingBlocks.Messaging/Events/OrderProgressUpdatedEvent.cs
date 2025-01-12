namespace BuildingBlocks.Messaging.Events
{
    public record OrderProgressUpdatedEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; } = default!;
        public Guid DriverId { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string Latitude { get; set; } = default!;
        public string Longitude { get; set; } = default!;
        public string Zip { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string AddressLine1 { get; set; } = default!;
        public string AddressLine2 { get; set; } = default!;

    }
}
