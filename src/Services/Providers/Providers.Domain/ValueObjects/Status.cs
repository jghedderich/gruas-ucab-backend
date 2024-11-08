
namespace Providers.Domain.ValueObjects;

public record Status 
{
    public StatusType Type { get; } = default!;
    private Status(StatusType type)
    {
        Type = type;
    }

    public static Status Of(StatusType type)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(type.ToString());
        
        return new Status(type);
    }
}
public enum StatusType
{
    Available,
    Unavailable,
}
