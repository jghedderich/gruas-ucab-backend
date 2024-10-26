using BuildingBlocks.Abstractions;
using Users.Domain.Entities;

public record UserCreatedEvent(User User) : IDomainEvent;

