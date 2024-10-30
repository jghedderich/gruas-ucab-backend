

namespace Orders.Domain.ValueObjects;

public record OrderStatus
{
    public Status Status { get; } = default!;

    private OrderStatus(Status status)
    {
        Status = status;
    }

    public static OrderStatus Of(Status status)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(status.ToString());

        return new OrderStatus(status);
    }
}

public enum Status
{
    ToBeAssigned,
    ToBeAccepted,
    Accepted,
    InProcess,
    Completed,
    Canceled
}