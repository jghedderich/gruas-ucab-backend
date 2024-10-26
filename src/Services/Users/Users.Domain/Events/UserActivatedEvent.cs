using BuildingBlocks.Abstractions;
using Users.Domain.Entities;

public record UserActivatedEvent(User User) : IDomainEvent;

