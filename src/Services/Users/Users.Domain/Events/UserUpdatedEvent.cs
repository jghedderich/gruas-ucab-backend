using BuildingBlocks.Abstractions;
using Users.Domain.Entities;

public record UserUpdatedEvent(User User) : IDomainEvent;