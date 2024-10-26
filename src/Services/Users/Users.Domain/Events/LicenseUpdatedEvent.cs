using BuildingBlocks.Abstractions;
using Users.Domain.Entities;

public record LicenseUpdatedEvent(Conductor User) : IDomainEvent;

