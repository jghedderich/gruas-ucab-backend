using FluentAssertions;
using FluentValidation.TestHelper;
using Providers.Application.Drivers.Commands.CreateDriver;

namespace Providers.Tests.Application.Drivers.Commands.CreateDriver
{
    public class CreateDriverCommandTests
    {
        [Fact]
        public void CreateDriverCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var driverDto = DriverDtoHelper.CreateDriverDto(Guid.NewGuid(), "John", "Doe", "john.doe@example.com", "123456789", "04121234567", "some-token");

            // Act
            var command = new CreateDriverCommand(driverDto);

            // Assert
            command.Driver.Should().Be(driverDto);
        }

        [Fact]
        public void CreateDriverResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var result = new CreateDriverResult(id);

            // Assert
            result.Id.Should().Be(id);
        }

        [Fact]
        public void CreateDriverCommandValidator_ShouldHaveValidationError_WhenPhoneIsEmpty()
        {
            // Arrange
            var validator = new CreateDriverCommandValidator();
            var driverDto = DriverDtoHelper.CreateDriverDto(Guid.NewGuid(), "John", "Doe", "john.doe@example.com", "123456789", null, "some-token");
            var command = new CreateDriverCommand(driverDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Driver.Phone).WithErrorMessage("Phone is required");
        }

        [Fact]
        public void CreateDriverCommandValidator_ShouldHaveValidationError_WhenEmailIsEmpty()
        {
            // Arrange
            var validator = new CreateDriverCommandValidator();
            var driverDto = DriverDtoHelper.CreateDriverDto(Guid.NewGuid(), "John", "Doe", null, "123456789", "04121234567", "some-token");
            var command = new CreateDriverCommand(driverDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Driver.Email).WithErrorMessage("Email is required");
        }

        [Fact]
        public void CreateDriverCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new CreateDriverCommandValidator();
            var driverDto = DriverDtoHelper.CreateDriverDto(Guid.NewGuid(), "John", "Doe", "john.doe@example.com", "123456789", "04121234567", "some-token");
            var command = new CreateDriverCommand(driverDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.Name);
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.Dni);
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.Phone);
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.Email);
        }
    }
}
