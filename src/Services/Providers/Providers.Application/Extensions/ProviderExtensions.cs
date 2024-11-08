
namespace Providers.Application.Extensions;

public static class ProviderExtensions
{
    public static IEnumerable<ProviderDto> ToProviderDtoList(this IEnumerable<Provider> providers)
    {
        return providers.Select(p => new ProviderDto(
            Id: p.Id,
            Name: new NameDto(p.ProviderName.FirstName, p.ProviderName.LastName),
            Phone: p.Phone.Value,
            Email: p.Email.Value,
            Password: p.Password.Value,
            Dni: new DniDto(Type: p.Dni.Type.ToString(), Number: p.Dni.Number),
            Company: new CompanyDto(
                p.Company.Name,
                p.Company.Description,
                p.Company.Rif,
                p.Company.State,
                p.Company.City),
            Vehicles: p.Vehicles.Select(v => new VehicleDto(v.Id, v.ProviderId, v.Type.ToString(), v.Brand.Value, v.Model.Value, v.Year, v.IsActive)).ToList(),
            Drivers: p.Drivers.Select(d =>
                new DriverDto(d.Id, d.VehicleId, d.ProviderId,
                    new NameDto(d.DriverName.FirstName, d.DriverName.LastName),
                    new DniDto(d.Dni.Type.ToString(), d.Dni.Number),
                    d.Phone.Value,
                    d.Email.Value,
                    d.Password.Value,
                    new StatusDto(d.Status.ToString()),
                    d.IsActive)).ToList(),

            IsActive: p.IsActive
        ));
    }

    public static ProviderDto ToProviderDto(this Provider provider)
    {
        return DtoFromProvider(provider);
    }

    private static ProviderDto DtoFromProvider(Provider provider)
    {
        return new ProviderDto(
                Id: provider.Id,
                Name: new NameDto(provider.ProviderName.FirstName, provider.ProviderName.LastName),
                Phone: provider.Phone.Value,
                Email: provider.Email.Value,
                Password: provider.Password.Value,
                Dni: new DniDto(provider.Dni.Type.ToString(), provider.Dni.Number),
                Company: new CompanyDto(
                    provider.Company.Name,
                    provider.Company.Description,
                    provider.Company.Rif,
                    provider.Company.State,
                    provider.Company.City),
                Vehicles: provider.Vehicles.Select(v => new VehicleDto(v.Id,v.ProviderId, v.Type.ToString(), v.Brand.Value, v.Model.Value, v.Year, v.IsActive)).ToList(),
                Drivers: provider.Drivers.Select(d => 
                    new DriverDto(d.Id, d.VehicleId,d.ProviderId, new NameDto(d.DriverName.FirstName, d.DriverName.LastName), 
                    new DniDto(d.Dni.Type.ToString(), d.Dni.Number),
                    d.Phone.Value,d.Email.Value, d.Password.Value, new StatusDto(d.Status.ToString()), d.IsActive)).ToList(),
                IsActive: provider.IsActive
        );
    }
}
