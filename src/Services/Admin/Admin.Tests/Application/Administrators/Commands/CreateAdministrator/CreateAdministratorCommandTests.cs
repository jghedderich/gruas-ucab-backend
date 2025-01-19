using FluentAssertions;
using FluentValidation.TestHelper;
using Admin.Application.Administrators.Commands.CreateAdministrator;

namespace Admin.Tests.Application.Administrators.Commands.CreateAdministrator
{
    public class CreateAdministratorCommandTests
    {
        [Fact]
        public void CreateAdministratorCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var administratorDto = AdministratorDtoHelper.CreateAdministratorDto(
                Guid.NewGuid(), "John", "Doe", "john.doe@example.com", "password");

            // Act
            var command = new CreateAdministratorCommand(administratorDto);

            // Assert
            command.Administrator.Should().Be(administratorDto);
        }

        [Fact]
        public void CreateAdministratorResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var result = new CreateAdministratorResult(id);

            // Assert
            result.Id.Should().Be(id);
        }

        [Fact]
        public void CreateAdministratorCommandValidator_ShouldHaveValidationError_WhenEmailIsEmpty()
        {
            // Arrange
            var validator = new CreateAdministratorCommandValidator();
            var administratorDto = AdministratorDtoHelper.CreateAdministratorDto(
                Guid.NewGuid(), "John", "Doe", null, "password");
            var command = new CreateAdministratorCommand(administratorDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Administrator.Email).WithErrorMessage("Email is required");
        }

        [Fact]
        public void CreateAdministratorCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new CreateAdministratorCommandValidator();
            var administratorDto = AdministratorDtoHelper.CreateAdministratorDto(
                Guid.NewGuid(), "John", "Doe", "john.doe@example.com", "password");
            var command = new CreateAdministratorCommand(administratorDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Administrator.Name);
            result.ShouldNotHaveValidationErrorFor(x => x.Administrator.Email);
            result.ShouldNotHaveValidationErrorFor(x => x.Administrator.Password);
        }
    }
}