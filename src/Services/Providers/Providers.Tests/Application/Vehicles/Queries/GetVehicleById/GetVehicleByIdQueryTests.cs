using FluentAssertions;
using Providers.Application.Vehicles.Queries.GetVehicleById;

namespace Providers.Tests.Application.Vehicles.Queries.GetVehicleById
{
    public class GetVehicleByIdQueryTests
    {
        [Fact]
        public void GetVehicleByIdQuery_ShouldInitializeCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var query = new GetVehicleByIdQuery(id);

            // Assert
            query.Id.Should().Be(id);
        }

        [Fact]
        public void GetVehicleByIdResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var vehicleDto = new VehicleDto(
                Guid.NewGuid(), Guid.NewGuid(), "Car", "Toyota", "Corolla", 2020, "ABC123", "Red", true);

            // Act
            var result = new GetVehicleByIdResult(vehicleDto);

            // Assert
            result.Vehicle.Should().Be(vehicleDto);
        }
    }
}


