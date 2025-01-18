using FluentAssertions;
using Providers.Application.Providers.Queries.AuthenticateProvider;
using Providers.Domain.ValueObjects;

namespace Providers.Tests.Application.Providers.Queries.AuthenticateProvider
{
    public class AuthenticateProviderQueryTests
    {
        [Fact]
        public void AuthenticateProviderQuery_ShouldInitializeCorrectly()
        {
            // Arrange
            var email = Email.Of("john.doe@example.com");
            var password = Password.Of("password");

            // Act
            var query = new AuthenticateProviderQuery(email, password);

            // Assert
            query.Email.Should().Be(email);
            query.Password.Should().Be(password);
        }

        [Fact]
        public void AuthenticateProviderResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var providerDto = new ProviderDto(Guid.NewGuid(), new NameDto("John", "Doe"), "04121234567", "john.doe@example.com", "password", new DniDto("V", "123456789"), new CompanyDto("CompanyName", "CompanyDescription", "RIF123", "State", "City"), new List<VehicleDto>(), new List<DriverDto>(), true);
            var token = "some-token";

            // Act
            var result = new AuthenticateProviderResult(providerDto, token);

            // Assert
            result.Provider.Should().Be(providerDto);
            result.Token.Should().Be(token);
        }
    }
}
