using Orders.Domain.Events;

namespace Orders.Domain.Models;

public class Policy : Aggregate<Guid>
{
    private readonly List<Order> _orders = [];
    public ICollection<Order> Orders => _orders;
    public string Name { get; private set; } = default!;
    public int AmountCovered { get; private set; } = default!;
    public Price Price { get; private set; } = default!;
    public Fee Fees { get; private set; } = default!;

    public static Policy Create(
            Guid id,
            string name,
            int ammountCovered,
            Price price,
            Fee fees
        )
    {
        var policy = new Policy
        {
            Id = id,
            Name = name,
            AmountCovered = ammountCovered,
            Price = price,
            Fees = fees
        };

        policy.AddDomainEvent(new PolicyCreatedEvent(policy));

        return policy;
    }

    public void Update( string name, int ammountCovered, Price price, Fee fees)
    {
        Name = name;
        AmountCovered = ammountCovered;
        Price = price;
        Fees = fees;

        AddDomainEvent(new PolicyUpdatedEvent(this));
    }

}
