using FluentAssertions;
using Providers.Application.Drivers.Queries.GetDrivers;

namespace Providers.Tests.Application.Drivers.Queries.GetDrivers
{
    public class GetDriversQueryTests
    {
        [Fact]
        public void GetDriversQuery_ShouldInitializeCorrectly()
        {
            // Arrange
            var paginationRequest = new PaginationRequest { PageIndex = 1, PageSize = 10 };

            // Act
            var query = new GetDriversQuery(paginationRequest);

            // Assert
            query.PaginationRequest.Should().Be(paginationRequest);
        }

        [Fact]
        public void GetDriversResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var drivers = new List<DriverDto>
            {
                DriverDtoHelper.CreateDriverDto(Guid.NewGuid(), "John", "Doe", "john.doe@example.com", "123456789", "04121234567", "some-token"),
                DriverDtoHelper.CreateDriverDto(Guid.NewGuid(), "Jane", "Doe", "jane.doe@example.com", "987654321", "04121234568", "some-token")
            };
            var paginatedResult = new PaginatedResult<DriverDto>(1, 10, drivers.Count, drivers);

            // Act
            var result = new GetDriversResult(paginatedResult);

            // Assert
            result.Drivers.Should().Be(paginatedResult);
        }
    }
}

