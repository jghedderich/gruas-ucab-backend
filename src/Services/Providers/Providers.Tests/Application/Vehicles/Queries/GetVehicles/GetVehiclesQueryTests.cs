using FluentAssertions;
using Providers.Application.Vehicles.Queries.GetVehicles;

namespace Providers.Tests.Application.Vehicles.Queries.GetVehicles
{
    public class GetVehiclesQueryTests
    {
        [Fact]
        public void GetVehiclesQuery_ShouldInitializeCorrectly()
        {
            // Arrange
            var paginationRequest = new PaginationRequest(1, 10);

            // Act
            var query = new GetVehiclesQuery(paginationRequest);

            // Assert
            query.PaginationRequest.Should().Be(paginationRequest);
        }

        [Fact]
        public void GetVehiclesResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var vehicles = new PaginatedResult<VehicleDto>(1, 10, 100, new List<VehicleDto>());

            // Act
            var result = new GetVehiclesResult(vehicles);

            // Assert
            result.Vehicles.Should().Be(vehicles);
        }
    }
}


