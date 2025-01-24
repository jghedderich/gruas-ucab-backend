using FluentAssertions;
using Admin.Application.Administrators.Queries.RequestCode;
using Admin.Domain.ValueObjects;

namespace Admin.Tests.Application.Administrators.Queries.RequestCode
{
    public class RequestCodeQueryTests
    {
        [Fact]
        public void RequestCodeQuery_ShouldInitializeCorrectly()
        {
            // Arrange
            var email = Email.Create("john.doe@example.com");
            var type = "some-type";

            // Act
            var query = new RequestCodeQuery(email, type);

            // Assert
            query.Email.Should().Be(email);
            query.Type.Should().Be(type);
        }

        [Fact]
        public void RequestCodeResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new RequestCodeResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }
    }
}
