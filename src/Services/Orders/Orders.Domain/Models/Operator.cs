

using Orders.Domain.Events;

namespace Orders.Domain.Models;

public class Operator : Aggregate<Guid>
{
    private readonly List<Order> _orders = [];
    public IReadOnlyList<Order> Orders => _orders.AsReadOnly();
    public OperatorName OperatorName { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Phone Phone { get; private set; } = default!;
    public Dni Dni { get; private set; } = default!;

    public static Operator Create(
            Guid id,
            OperatorName operatorName,
            Email email,
            Phone phone,
            Dni dni
        )
    {
        var operatorD = new Operator
        {
            Id = id,
            OperatorName = operatorName,
            Email = email,
            Phone = phone,
            Dni = dni
        };

        operatorD.AddDomainEvent(new OperatorCreatedEvent(operatorD));

        return operatorD;
    }

    public void Update(OperatorName operatorName)
    {
        OperatorName = operatorName;

        AddDomainEvent(new OperatorUpdatedEvent(this));
    }

    public void AddOrder(Guid orderId, PolicyDetails policyDetails,OrderStatus orderStatus, List<CostDetail> additionalCost)
    {
        var order = Order.Create(orderId,Id,policyDetails,orderStatus,additionalCost);
        _orders.Add(order);
    }

    public void RemoveOrder(Guid orderId) 
    { 
        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            _orders.Remove(order);
        }
    }

}
