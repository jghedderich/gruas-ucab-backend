
namespace Providers.Domain.Models;

public class Provider : Aggregate<ProviderId>
{
    private readonly List<Driver> _drivers = [];
    public IReadOnlyList<Driver> Drivers => _drivers.AsReadOnly();
    public ProviderId ProviderId { get; private set; } = default!;
    public ProviderName? ProviderName { get; private set; } = default;
    public RIF Rif { get; private set; } = default!;
    public Company Company { get; private set; } = default!;

    //to be determined...
}
