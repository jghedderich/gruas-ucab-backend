using FluentAssertions;
using FluentValidation.TestHelper;
using Admin.Application.Administrators.Commands.UpdateAdministratorPassword;

namespace Admin.Tests.Application.Administrators.Commands.UpdateAdministratorPassword
{
    public class UpdateAdministratorPasswordCommandTests
    {
        [Fact]
        public void UpdateAdministratorPasswordCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var updatePasswordDto = new UpdatePasswordDto(Guid.NewGuid(), "new-password");

            // Act
            var command = new UpdateAdministratorPasswordCommand(updatePasswordDto);

            // Assert
            command.Administrator.Should().Be(updatePasswordDto);
        }

        [Fact]
        public void UpdateAdministratorPasswordResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new UpdateAdministratorPasswordResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }

        [Fact]
        public void UpdateAdministratorPasswordCommandValidator_ShouldHaveValidationError_WhenNewPasswordIsEmpty()
        {
            // Arrange
            var validator = new UpdateAdministratorPasswordCommandValidator();
            var updatePasswordDto = new UpdatePasswordDto(Guid.NewGuid(), null);
            var command = new UpdateAdministratorPasswordCommand(updatePasswordDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Administrator.NewPassword).WithErrorMessage("New Password is required");
        }

        [Fact]
        public void UpdateAdministratorPasswordCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new UpdateAdministratorPasswordCommandValidator();
            var updatePasswordDto = new UpdatePasswordDto(Guid.NewGuid(), "new-password");
            var command = new UpdateAdministratorPasswordCommand(updatePasswordDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Administrator.Id);
            result.ShouldNotHaveValidationErrorFor(x => x.Administrator.NewPassword);
        }
    }
}
