

namespace Orders.Domain.ValueObjects;

public record CostDetailStatus
{
    public StatusCO StatusCO { get; } = default!;

    private CostDetailStatus(StatusCO statusCO)
    {
        StatusCO = statusCO;
    }

    public static CostDetailStatus Of(StatusCO statusCO)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(statusCO.ToString());

        return new CostDetailStatus(statusCO);
    }
}

public enum StatusCO
{
    Pending,
    Approved,
    Rejected
}