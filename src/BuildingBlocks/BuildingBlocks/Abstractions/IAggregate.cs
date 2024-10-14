namespace BuildingBlocks.Abstractions;

public interface IAggregate<T> : IAggregate, IEntity<T>
{
}

public interface IAggregate : IEntity
{
    IReadOnlyList<IDomainEvent> domainEvents { get; }
    IDomainEvent[] ClearDomainEvents();
}
