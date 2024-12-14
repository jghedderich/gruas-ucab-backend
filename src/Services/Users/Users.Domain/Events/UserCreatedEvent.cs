
namespace Users.Domain.Events;

public record UserCreatedEvent(User User) : IDomainEvent;
