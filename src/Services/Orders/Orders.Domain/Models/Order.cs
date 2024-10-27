using Orders.Domain.Events;
using System.Data;

namespace Orders.Domain.Models;

public class Order : Aggregate<Guid>
{
    public Guid OperatorId { get; private set; } = default!;
    public PolicyDetails PolicyDetails { get; private set; } = default!;
    public OrderStatus OrderStatus { get; private set; } = default!;
    public List<CostDetail> AdditionalCost { get; private set; } = default!;


    public static Order Create(
            Guid id,
            Guid operatorId,
            PolicyDetails policyDetails,
            OrderStatus orderStatus,
            List<CostDetail> additionalCost
        )
    {
        var order = new Order
        {
            Id = id,
            OperatorId = operatorId,
            PolicyDetails = policyDetails,
            OrderStatus = orderStatus,
            AdditionalCost = additionalCost
        };

        order.AddDomainEvent(new OrderCreatedEvent(order));

        return order;
    }

    public void Update(PolicyDetails policyDetails, List<CostDetail> additionalCost)
    {
        PolicyDetails = policyDetails;
        AdditionalCost = additionalCost;

        AddDomainEvent(new OrderUpdatedEvent(this));
    }

    public void UpdateStatus(OrderStatus newStatus)
    {
        OrderStatus = newStatus;

        AddDomainEvent(new OrderUpdatedEvent(this));
    }
    

    public void AddAdditionalCost(CostDetail cost)
    {
        AdditionalCost.Add(cost);
    }
}
