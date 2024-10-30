namespace BuildingBlocks.Messaging.Events
{
    public record OrderCreatedEvent : IntegrationEvent
    {
        public Guid OperatorId { get; set; } = default!;
        public string ClientName { get; set; } = default!;
        public string ClientDni { get; set; } = default!;
        public string ClientPhone { get; set; } = default!;
        public string Policy { get; set; } = default!;

        // Location Address
        public string LocationLatitude { get; set; } = default!;
        public string LocationLongitude { get; set; } = default!;
        public string LocationCity { get; set; } = default!;
        public string LocationState { get; set; } = default!;

        // Destiny Address
        public string DestinyLatitude { get; set; } = default!;
        public string DestinyLongitude { get; set; } = default!;
        public string DestinyCity { get; set; } = default!;
        public string DestinyState { get; set; } = default!;
    }
}
