using FluentAssertions;
using FluentValidation.TestHelper;
using Providers.Application.Drivers.Commands.UpdateDriverPassword;

namespace Providers.Tests.Application.Drivers.Commands.UpdateDriverPassword
{
    public class UpdateDriverPasswordCommandTests
    {
        [Fact]
        public void UpdateDriverPasswordCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var updatePasswordDto = new UpdatePasswordDto(Guid.NewGuid(), "new-password");

            // Act
            var command = new UpdateDriverPasswordCommand(updatePasswordDto);

            // Assert
            command.Driver.Should().Be(updatePasswordDto);
        }

        [Fact]
        public void UpdateDriverPasswordResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new UpdateDriverPasswordResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }

        [Fact]
        public void UpdateDriverPasswordCommandValidator_ShouldHaveValidationError_WhenIdIsEmpty()
        {
            // Arrange
            var validator = new UpdateDriverPasswordCommandValidator();
            var updatePasswordDto = new UpdatePasswordDto(Guid.Empty, "new-password");
            var command = new UpdateDriverPasswordCommand(updatePasswordDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Driver.Id).WithErrorMessage("Id is required");
        }

        [Fact]
        public void UpdateDriverPasswordCommandValidator_ShouldHaveValidationError_WhenNewPasswordIsEmpty()
        {
            // Arrange
            var validator = new UpdateDriverPasswordCommandValidator();
            var updatePasswordDto = new UpdatePasswordDto(Guid.NewGuid(), null);
            var command = new UpdateDriverPasswordCommand(updatePasswordDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Driver.NewPassword).WithErrorMessage("New Password is required");
        }

        [Fact]
        public void UpdateDriverPasswordCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new UpdateDriverPasswordCommandValidator();
            var updatePasswordDto = new UpdatePasswordDto(Guid.NewGuid(), "new-password");
            var command = new UpdateDriverPasswordCommand(updatePasswordDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.Id);
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.NewPassword);
        }
    }
}




