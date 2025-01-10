using Orders.Domain.Events;

namespace Orders.Domain.Models;

public class Order : Aggregate<Guid>
{
    private readonly List<CostDetail> _costDetail = [];
    public ICollection<CostDetail> CostDetails => _costDetail;
    public Guid OperatorId { get; private set; } = default!;
    public Guid PolicyId { get; private set; } = default!;
    public Client Client { get; private set; } = default!; // CLIENTE
    public OrderStatus OrderStatus { get; private set; } = default!;
    public Address IncidentAddress { get; private set; } = default!; // DIRECCION DEL ACCIDENTE-INCIDENTE
    public Address DestinationAddress { get; private set; } = default!; // DIRECCION DESTINO
    public Bill Bill { get; private set; } = default!;
    public Guid DriverId { get; private set; } = default!;


    public static Order Create(
            Guid id,
            Guid operatorId,
            Guid policyId,
            Client client,
            OrderStatus orderStatus,
            Address incidentAddress,
            Address destinationAddress,
            Bill bill,
            Guid driverId
        )
    {
        var order = new Order
        {
            Id = id,
            OperatorId = operatorId,
            PolicyId = policyId,
            Client = client,
            OrderStatus = orderStatus,
            IncidentAddress = incidentAddress,
            DestinationAddress = destinationAddress,
            Bill = bill,
            DriverId = driverId
        };

        order.AddDomainEvent(new OrderCreatedEvent(order));

        return order;
    }

    public void Update( Client client, Address incidentAddress, Address destinationAddress)
    {
        Client = client;
        IncidentAddress = incidentAddress;
        DestinationAddress = destinationAddress;

        AddDomainEvent(new OrderUpdatedEvent(this));
    }

    public void UpdateStatus(OrderStatus newStatus)
    {
        OrderStatus = newStatus;

        AddDomainEvent(new OrderStatusUpdatedEvent(Id, newStatus));
    }

    public void UpdateOrderDriver(Guid driverId)
    {
        DriverId = driverId;

        AddDomainEvent(new OrderUpdatedEvent(this));
    }

    public void AddCostDetail(Guid costDetailId, string description, decimal amount, CostDetailStatus statusC)
    {
        var costDetail = CostDetail.Create(costDetailId, Id, description, amount, statusC);
        _costDetail.Add(costDetail);
        
        foreach (var cost in _costDetail)
        {
            Bill.Subtotal += cost.Amount;
        }

    }

    public void RemoveCostDetail(Guid costDetailId)
    { 
        var costDetail = _costDetail.FirstOrDefault(c => c.Id == costDetailId);
        if (costDetail != null) 
        { 
            _costDetail.Remove(costDetail);
        }
    }
}
