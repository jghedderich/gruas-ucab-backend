

using Orders.Domain.Events;

namespace Orders.Domain.Models;

public class Operator : Aggregate<Guid>
{
    private readonly List<Order> _orders = [];
    public IReadOnlyList<Order> Orders => _orders.AsReadOnly();
    public Name OperatorName { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Phone Phone { get; private set; } = default!;
    public Dni Dni { get; private set; } = default!;
    public Password Password { get; private set; } = default!;

    public static Operator Create(
            Guid id,
            Name operatorName,
            Email email,
            Phone phone,
            Dni dni,
            Password password
        )
    {
        var operatorD = new Operator
        {
            Id = id,
            OperatorName = operatorName,
            Email = email,
            Phone = phone,
            Dni = dni,
            Password = password
        };

        operatorD.AddDomainEvent(new OperatorCreatedEvent(operatorD));

        return operatorD;
    }

    public void Update(Name operatorName, Email email, Phone phone, Dni dni, Password password)
    {
        OperatorName = operatorName;
        Email = email;
        Phone = phone;
        Dni = dni;
        Password = password;

        AddDomainEvent(new OperatorUpdatedEvent(this));
    }

    public void AddOrder(Guid orderId, Guid policyId, Client client, OrderStatus orderStatus, Address incidentAddress, Address destinationAddress)
    {
        var order = Order.Create(orderId, Id, policyId, client, orderStatus, incidentAddress, destinationAddress);
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
