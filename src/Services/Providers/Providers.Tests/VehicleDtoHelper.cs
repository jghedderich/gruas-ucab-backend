

namespace Providers.Tests
{
    public static class VehicleDtoHelper
    {
        public static VehicleDto CreateVehicleDto(Guid id, Guid providerId, string type, string brand, string model, int year, string licensePlate, string color, bool? isActive)
        {
            return new VehicleDto(
                Id: id,
                ProviderId: providerId,
                Type: type,
                Brand: brand,
                Model: model,
                Year: year,
                LicensePlate: licensePlate,
                Color: color,
                IsActive: isActive
            );
        }
    }
}
