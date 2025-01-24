using FluentAssertions;
using Providers.Application.Providers.Queries.VerifyCode;
using Providers.Domain.ValueObjects;

namespace Providers.Tests.Application.Providers.Queries.VerifyCode
{
    public class VerifyCodeQueryTests
    {
        [Fact]
        public void VerifyCodeQuery_ShouldInitializeCorrectly()
        {
            // Arrange
            var email = Email.Of("john.doe@example.com");
            var code = "some-code";

            // Act
            var query = new VerifyCodeQuery(email, code);

            // Assert
            query.Email.Should().Be(email);
            query.Code.Should().Be(code);
        }

        [Fact]
        public void VerifyCodeResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var verifyDto = new VerifyCodeDto(Guid.NewGuid(), true);

            // Act
            var result = new VerifyCodeResult(verifyDto);

            // Assert
            result.VerifyDto.Should().Be(verifyDto);
        }
    }
}
