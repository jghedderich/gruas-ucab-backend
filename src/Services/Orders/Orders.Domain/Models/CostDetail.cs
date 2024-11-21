
namespace Orders.Domain.Models;

public class CostDetail : Aggregate<Guid>
{
    public Guid OrderId { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public double Amount { get; private set; } = default!;
    public bool IsApproved { get; private set; } = default!;

    public static CostDetail Create(
            Guid id,
            Guid orderId,
            string description,
            double amount,
            bool isApproved
        )
    {
        var costDetail = new CostDetail
        {
            Id = id,
            OrderId = orderId,
            Description = description,
            Amount = amount,
            IsApproved = isApproved
        };

        return costDetail;
    }

    public void Update(string description, double amount, bool isApproved)
    {
        Description = description;
        Amount = amount;
        IsApproved = isApproved;
    }

}