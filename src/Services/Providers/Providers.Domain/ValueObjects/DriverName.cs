
namespace Providers.Domain.ValueObjects;

public record DriverName
{
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;
}
