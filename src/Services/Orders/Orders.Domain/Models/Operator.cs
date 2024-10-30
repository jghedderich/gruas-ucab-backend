

using Orders.Domain.Events;

namespace Orders.Domain.Models;

public class Operator : Aggregate<Guid>
{
    public Name OperatorName { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Phone Phone { get; private set; } = default!;
    public Dni Dni { get; private set; } = default!;

    public static Operator Create(
            Guid id,
            Name operatorName,
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

    public void Update(Name operatorName, Email email, Phone phone, Dni dni)
    {
        OperatorName = operatorName;
        Email = email;
        Phone = phone;
        Dni = dni;

        AddDomainEvent(new OperatorUpdatedEvent(this));
    }
}
