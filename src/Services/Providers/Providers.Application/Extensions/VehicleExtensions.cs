namespace Providers.Application.Extensions;

public static class VehicleExtensions
{
    public static IEnumerable<VehicleDto> ToVehicleDtoList(this IEnumerable<VehicleDto> vehicles)
    {
        return vehicles.Select(v => new VehicleDto(
                Id: v.Id,
                ProviderId: v.ProviderId,
                Type: v.Type,
                Brand: v.Brand,
                Model: v.Model,
                Year: v.Year,
                LicensePlate: v.LicensePlate,
                Color: v.Color,
                IsActive: v.IsActive
            ));
    }

    public static VehicleDto ToVehicleDto(this Vehicle vehicle)
    {
        return DtoFromVehicle(vehicle);
    }

    private static VehicleDto DtoFromVehicle(Vehicle vehicle)
    {
        return new VehicleDto(
                Id: vehicle.Id,
                ProviderId: vehicle.ProviderId,
                Type: vehicle.Type.ToString(),
                Brand: vehicle.Brand.Value,
                Model: vehicle.Model.Value,
                Year: vehicle.Year,
                LicensePlate: vehicle.LicensePlate,
                Color: vehicle.Color,
                IsActive: vehicle.IsActive
            );
    }
}
