using BuildingBlocks.Abstractions;
using Users.Domain.Entities;

public record PasswordChangedEvent(User User) : IDomainEvent;

