using BuildingBlocks.Abstractions;
using Users.Domain.Entities;

public record UserDeactivatedEvent(User User) : IDomainEvent;

