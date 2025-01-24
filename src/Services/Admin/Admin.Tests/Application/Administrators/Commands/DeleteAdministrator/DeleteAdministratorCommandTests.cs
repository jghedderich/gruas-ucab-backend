using FluentAssertions;
using FluentValidation.TestHelper;
using Admin.Application.Administrators.Commands.DeleteAdministrator;

namespace Admin.Tests.Application.Administrators.Commands.DeleteAdministrator
{
    public class DeleteAdministratorCommandTests
    {
        [Fact]
        public void DeleteAdministratorCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var administratorId = Guid.NewGuid();

            // Act
            var command = new DeleteAdministratorCommand(administratorId);

            // Assert
            command.AdministratorId.Should().Be(administratorId);
        }

        [Fact]
        public void DeleteAdministratorResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new DeleteAdministratorResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }

        [Fact]
        public void DeleteAdministratorCommandValidator_ShouldHaveValidationError_WhenAdministratorIdIsEmpty()
        {
            // Arrange
            var validator = new DeleteAdministratorCommandValidator();
            var command = new DeleteAdministratorCommand(Guid.Empty);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.AdministratorId).WithErrorMessage("El Administrador es requerido");
        }

        [Fact]
        public void DeleteAdministratorCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new DeleteAdministratorCommandValidator();
            var command = new DeleteAdministratorCommand(Guid.NewGuid());

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.AdministratorId);
        }
    }
}
