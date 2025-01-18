namespace Providers.Tests
{
    public static class DriverDtoHelper
    {
        public static DriverDto CreateDriverDto(Guid id, string firstName, string lastName, string email, string dniNumber, string phone, string token)
        {
            return new DriverDto(
                Id: id,
                VehicleId: Guid.NewGuid(),
                ProviderId: Guid.NewGuid(),
                Name: new NameDto(firstName, lastName),
                Dni: new DniDto("V", dniNumber),
                Phone: phone,
                Email: email,
                Password: "password",
                Status: "Available",
                Location: new LocationDto(
                    "Address1", "Address2", "1060",
                    "Miranda", "Caracas",
                    new CoordinatesDto("10.507365", "-66.859987")),
                IsActive: true,
                Token: token
            );
        }
    }
}

