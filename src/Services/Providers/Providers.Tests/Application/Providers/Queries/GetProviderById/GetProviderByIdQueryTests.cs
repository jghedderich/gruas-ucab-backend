using FluentAssertions;
using Providers.Application.Providers.Queries.GetProviderById;

namespace Providers.Tests.Application.Providers.Queries.GetProviderById
{
    public class GetProviderByIdQueryTests
    {
        [Fact]
        public void GetProviderByIdQuery_ShouldInitializeCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var query = new GetProviderByIdQuery(id);

            // Assert
            query.Id.Should().Be(id);
        }

        [Fact]
        public void GetProviderByIdResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var providerDto = new ProviderDto(Guid.NewGuid(), new NameDto("John", "Doe"), "04121234567", "john.doe@example.com", "password", new DniDto("V", "123456789"), new CompanyDto("CompanyName", "CompanyDescription", "RIF123", "State", "City"), new List<VehicleDto>(), new List<DriverDto>(), true);

            // Act
            var result = new GetProviderByIdResult(providerDto);

            // Assert
            result.Provider.Should().Be(providerDto);
        }
    }
}
