
namespace Providers.Domain.Models;

public class Provider : Aggregate<ProviderId>
{
    public ProviderName ProviderName { get; private set; } = default!;
    public Phone Phone { get; private set; } = default!;
    public Dni Dni { get; private set; } = default!;
    public Company Company { get; private set; } = default!;

    public static Provider Create(
        ProviderId id, 
        ProviderName providerName, 
        Phone phone, 
        Dni dni,
        Company company
        )
    {
        var provider = new Provider
        {
            Id = id,
            ProviderName = providerName,
            Phone = phone,
            Dni = dni,
            Company = company,
        };

        provider.AddDomainEvent(new ProviderCreatedEvent(provider));

        return provider;
    }

    public void Update(ProviderName providerName, Company company, Phone phone)
    {
        ProviderName = providerName;
        Phone = phone;
        Company = company;

        AddDomainEvent(new ProviderUpdatedEvent(this));
    }

}
