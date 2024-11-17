using Admin.Domain.Models;

namespace Admin.Domain.Events;

public record RateUpdatedEvent(Rate Rate) : IDomainEvent;
