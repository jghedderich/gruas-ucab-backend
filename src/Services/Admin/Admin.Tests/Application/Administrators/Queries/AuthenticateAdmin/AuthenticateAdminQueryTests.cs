using FluentAssertions;
using Admin.Application.Administrators.Queries.AuthenticateAdmin;
using Admin.Domain.ValueObjects;

namespace Admin.Tests.Application.Administrators.Queries.AuthenticateAdmin
{
    public class AuthenticateAdminQueryTests
    {
        [Fact]
        public void AuthenticateAdminQuery_ShouldInitializeCorrectly()
        {
            // Arrange
            var email = Email.Create("john.doe@example.com");
            var password = Password.Create("password");

            // Act
            var query = new AuthenticateAdminQuery(email, password);

            // Assert
            query.Email.Should().Be(email);
            query.Password.Should().Be(password);
        }

        [Fact]
        public void AuthenticateAdminResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var administratorDto = new AdministratorDto(Guid.NewGuid(), new NameDto("John", "Doe"), "john.doe@example.com", "password");
            var token = "some-token";

            // Act
            var result = new AuthenticateAdminResult(administratorDto, token);

            // Assert
            result.Administrator.Should().Be(administratorDto);
            result.Token.Should().Be(token);
        }
    }
}
