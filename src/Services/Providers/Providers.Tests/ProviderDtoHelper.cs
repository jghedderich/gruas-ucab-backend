
namespace Providers.Tests
{
    public static class ProviderDtoHelper
    {
        public static ProviderDto CreateProviderDto(Guid id, string firstName, string lastName, string phone, string? email, string? password, string dniNumber, string companyName, string companyDescription, string companyRif, string companyState, string companyCity, List<VehicleDto> vehicles, List<DriverDto> drivers, bool? isActive)
        {
            return new ProviderDto(
                Id: id,
                Name: new NameDto(firstName, lastName),
                Phone: phone,
                Email: email,
                Password: password,
                Dni: new DniDto("V", dniNumber),
                Company: new CompanyDto(companyName, companyDescription, companyRif, companyState, companyCity),
                Vehicles: vehicles,
                Drivers: drivers,
                IsActive: isActive
            );
        }
    }
}
