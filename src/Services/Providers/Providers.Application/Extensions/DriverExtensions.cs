
namespace Providers.Application.Extensions;

public static class DriverExtensions
{
    public static IEnumerable<DriverDto> ToDriverDtoList(this IEnumerable<DriverDto> drivers)
    {
        return drivers.Select(p => new DriverDto(
                Id: p.Id,
                VehicleId: p.VehicleId,
                ProviderId: p.ProviderId,
                Name: new NameDto(p.Name.FirstName, p.Name.LastName),
                Dni: new DniDto(Type: p.Dni.Type.ToString(), Number: p.Dni.Number),
                Status: p.Status,
                Phone: p.Phone,
                Email: p.Email,
                Location: p.Location,
                Password: p.Password,
                IsActive: p.IsActive,
                Token: p.Token
            ));
    }

    public static DriverDto ToDriverDto(this Driver driver)
    {
        return DtoFromDriver(driver);
    }

    private static DriverDto DtoFromDriver(Driver driver)
    {
        return new DriverDto(
            Id: driver.Id,
            VehicleId: driver.VehicleId,
            ProviderId: driver.ProviderId,
            Name: new NameDto(driver.DriverName.FirstName, driver.DriverName.LastName),
            Dni: new DniDto(driver.Dni.Type.ToString(), driver.Dni.Number),
            Phone: driver.Phone.Value,
            Email: driver.Email.Value,
            Password: driver.Password.Value,
            Status: driver.Status.ToString(),
            Location: driver.Location != null ? new LocationDto(
                driver.Location.AddressLine1,
                driver.Location.AddressLine2,
                driver.Location.Zip,
                driver.Location.State,
                driver.Location.City,
                new CoordinatesDto(
                    driver.Location.Coordinates.Latitude,
                    driver.Location.Coordinates.Longitude
                )
            ) : null,
            IsActive: driver.IsActive,
            Token: driver.Token
        );
    }
}