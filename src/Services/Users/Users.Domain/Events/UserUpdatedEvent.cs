namespace Users.Domain.Events;

public record UserUpdatedEvent(User User) : IDomainEvent;
