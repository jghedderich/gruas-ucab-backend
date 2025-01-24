using FluentAssertions;
using FluentValidation.TestHelper;
using Providers.Application.Providers.Commands.UpdateProviderPassword;

namespace Providers.Tests.Application.Providers.Commands.UpdateProviderPassword
{
    public class UpdateProviderPasswordCommandTests
    {
        [Fact]
        public void UpdateProviderPasswordCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var updatePasswordDto = new UpdatePasswordDto(Guid.NewGuid(), "new-password");

            // Act
            var command = new UpdateProviderPasswordCommand(updatePasswordDto);

            // Assert
            command.Provider.Should().Be(updatePasswordDto);
        }

        [Fact]
        public void UpdateProviderPasswordResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new UpdateProviderPasswordResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }

        [Fact]
        public void UpdateProviderPasswordCommandValidator_ShouldHaveValidationError_WhenNewPasswordIsEmpty()
        {
            // Arrange
            var validator = new UpdateProviderPasswordCommandValidator();
            var updatePasswordDto = new UpdatePasswordDto(Guid.NewGuid(), null);
            var command = new UpdateProviderPasswordCommand(updatePasswordDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Provider.NewPassword).WithErrorMessage("New Password is required");
        }

        [Fact]
        public void UpdateProviderPasswordCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new UpdateProviderPasswordCommandValidator();
            var updatePasswordDto = new UpdatePasswordDto(Guid.NewGuid(), "new-password");
            var command = new UpdateProviderPasswordCommand(updatePasswordDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Provider.Id);
            result.ShouldNotHaveValidationErrorFor(x => x.Provider.NewPassword);
        }
    }
}
