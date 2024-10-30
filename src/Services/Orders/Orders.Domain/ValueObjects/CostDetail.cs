

namespace Orders.Domain.ValueObjects;

public record CostDetail
{
    public string Description { get; } = default!;
    public decimal Amount { get; } = default!;
    public bool IsApproved { get; } = default!;

    private CostDetail(string description, decimal amount, bool isApproved)
    {
        Description = description;
        Amount = amount;
        IsApproved = isApproved;
    }

    public static CostDetail Of(string description, decimal amount, bool isApproved)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentException.ThrowIfNullOrWhiteSpace(amount.ToString());
        ArgumentException.ThrowIfNullOrWhiteSpace(isApproved.ToString());

        return new CostDetail(description, amount, isApproved);
    }
}
