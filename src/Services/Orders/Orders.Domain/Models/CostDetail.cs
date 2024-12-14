
namespace Orders.Domain.Models;

public class CostDetail : Aggregate<Guid>
{
    public Guid OrderId { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public double Amount { get; private set; } = default!;
    public CostDetailStatus StatusC { get; private set; } = default!;

    public static CostDetail Create(
            Guid id,
            Guid orderId,
            string description,
            double amount,
            CostDetailStatus statusC
        )
    {
        var costDetail = new CostDetail
        {
            Id = id,
            OrderId = orderId,
            Description = description,
            Amount = amount,
            StatusC = statusC
        };

        return costDetail;
    }

    public void Update(string description, double amount)
    {
        Description = description;
        Amount = amount;
    }

    public void UpdateStatus(CostDetailStatus statusC)
    {
        StatusC = statusC;
    }

}