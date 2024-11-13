using Admin.Domain.Models;

namespace Admin.Domain.Events;

public record RateCreatedEvent(Rate Rate) : IDomainEvent;
