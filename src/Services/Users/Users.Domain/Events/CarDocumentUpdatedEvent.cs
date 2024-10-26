using BuildingBlocks.Abstractions;
using Users.Domain.Entities;

public record CarDocumentUpdatedEvent(Conductor User) : IDomainEvent;


