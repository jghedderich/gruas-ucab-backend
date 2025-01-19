using FluentAssertions;
using FluentValidation.TestHelper;
using Admin.Application.Administrators.Commands.UpdateAdministrator;

namespace Admin.Tests.Application.Administrators.Commands.UpdateAdministrator
{
    public class UpdateAdministratorCommandTests
    {
        [Fact]
        public void UpdateAdministratorCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var administratorDto = AdministratorDtoHelper.CreateAdministratorDto(
                Guid.NewGuid(), "John", "Doe", "john.doe@example.com", "password");

            // Act
            var command = new UpdateAdministratorCommand(administratorDto);

            // Assert
            command.Administrator.Should().Be(administratorDto);
        }

        [Fact]
        public void UpdateAdministratorResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new UpdateAdministratorResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }

        [Fact]
        public void UpdateAdministratorCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new UpdateAdministratorCommandValidator();
            var administratorDto = AdministratorDtoHelper.CreateAdministratorDto(
                Guid.NewGuid(), "John", "Doe", "john.doe@example.com", "password");
            var command = new UpdateAdministratorCommand(administratorDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Administrator.Name);
            result.ShouldNotHaveValidationErrorFor(x => x.Administrator.Email);
            result.ShouldNotHaveValidationErrorFor(x => x.Administrator.Password);
        }
    }
}
