using FluentAssertions;
using Providers.Application.Drivers.Queries.GetDriverById;

namespace Providers.Tests.Application.Drivers.Queries.GetDriverById
{
    public class GetDriverByIdQueryTests
    {
        [Fact]
        public void GetDriverByIdQuery_ShouldInitializeCorrectly()
        {
            // Arrange
            var driverId = Guid.NewGuid();

            // Act
            var query = new GetDriverByIdQuery(driverId);

            // Assert
            query.Id.Should().Be(driverId);
        }

        [Fact]
        public void GetDriverByIdResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var driver = DriverDtoHelper.CreateDriverDto(Guid.NewGuid(), "John", "Doe", "john.doe@example.com", "123456789", "04121234567", "some-token");

            // Act
            var result = new GetDriverByIdResult(driver);

            // Assert
            result.Driver.Should().Be(driver);
        }
    }
}

