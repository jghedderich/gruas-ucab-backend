using FluentAssertions;
using Drivers.Application.Drivers.Queries.AuthenticateDriver;
using Providers.Domain.ValueObjects;


namespace Providers.Tests.Application.Drivers.Queries.AuthenticateDriver
{
    public class AuthenticateDriverQueryTests
    {
        [Fact]
        public void AuthenticateDriverQuery_ShouldInitializeCorrectly()
        {
            // Arrange
            var email = Email.Of("john.doe@example.com");
            var password = Password.Of("password");
            var token = "some-token";

            // Act
            var query = new AuthenticateDriverQuery(email, password, token);

            // Assert
            query.Email.Should().Be(email);
            query.Password.Should().Be(password);
            query.Token.Should().Be(token);
        }

        [Fact]
        public void AuthenticateDriverResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var driver = DriverDtoHelper.CreateDriverDto(Guid.NewGuid(), "John", "Doe", "john.doe@example.com", "123456789", "04121234567", "some-token");
            var token = "new-token";

            // Act
            var result = new AuthenticateDriverResult(driver, token);

            // Assert
            result.Driver.Should().Be(driver);
            result.Token.Should().Be(token);
        }
    }
}