using FluentAssertions;
using FluentValidation.TestHelper;
using Providers.Application.Providers.Commands.DeleteProvider;

namespace Providers.Tests.Application.Providers.Commands.DeleteProvider
{
    public class DeleteProviderCommandTests
    {
        [Fact]
        public void DeleteProviderCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var providerId = Guid.NewGuid();

            // Act
            var command = new DeleteProviderCommand(providerId);

            // Assert
            command.ProviderId.Should().Be(providerId);
        }

        [Fact]
        public void DeleteProviderResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new DeleteProviderResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }

        [Fact]
        public void DeleteProviderCommandValidator_ShouldHaveValidationError_WhenProviderIdIsEmpty()
        {
            // Arrange
            var validator = new DeleteProviderCommandValidator();
            var command = new DeleteProviderCommand(Guid.Empty);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ProviderId).WithErrorMessage("ProviderId is required");
        }

        [Fact]
        public void DeleteProviderCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new DeleteProviderCommandValidator();
            var command = new DeleteProviderCommand(Guid.NewGuid());

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.ProviderId);
        }
    }
}
