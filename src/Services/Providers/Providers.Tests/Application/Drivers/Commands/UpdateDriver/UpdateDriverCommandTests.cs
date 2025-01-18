using FluentAssertions;
using FluentValidation.TestHelper;
using Providers.Application.Drivers.Commands.UpdateDriver;

namespace Providers.Tests.Application.Drivers.Commands.UpdateDriver
{
    public class UpdateDriverCommandTests
    {
        [Fact]
        public void UpdateDriverCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var driverDto = DriverDtoHelper.CreateDriverDto(Guid.NewGuid(), "John", "Doe", "john.doe@example.com", "123456789", "04121234567", "some-token");

            // Act
            var command = new UpdateDriverCommand(driverDto);

            // Assert
            command.Driver.Should().Be(driverDto);
        }

        [Fact]
        public void UpdateDriverResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new UpdateDriverResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }

        [Fact]
        public void UpdateDriverCommandValidator_ShouldHaveValidationError_WhenIdIsEmpty()
        {
            // Arrange
            var validator = new UpdateDriverCommandValidator();
            var driverDto = DriverDtoHelper.CreateDriverDto(Guid.Empty, "John", "Doe", "john.doe@example.com", "123456789", "04121234567", "some-token");
            var command = new UpdateDriverCommand(driverDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Driver.Id).WithErrorMessage("Id is required");
        }

        [Fact]
        public void UpdateDriverCommandValidator_ShouldHaveValidationError_WhenFirstNameIsEmpty()
        {
            // Arrange
            var validator = new UpdateDriverCommandValidator();
            var driverDto = DriverDtoHelper.CreateDriverDto(Guid.NewGuid(), null, "Doe", "john.doe@example.com", "123456789", "04121234567", "some-token");
            var command = new UpdateDriverCommand(driverDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Driver.Name.FirstName).WithErrorMessage("First name is required");
        }

        [Fact]
        public void UpdateDriverCommandValidator_ShouldHaveValidationError_WhenLastNameIsEmpty()
        {
            // Arrange
            var validator = new UpdateDriverCommandValidator();
            var driverDto = DriverDtoHelper.CreateDriverDto(Guid.NewGuid(), "John", null, "john.doe@example.com", "123456789", "04121234567", "some-token");
            var command = new UpdateDriverCommand(driverDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Driver.Name.LastName).WithErrorMessage("Last name is required");
        }

        [Fact]
        public void UpdateDriverCommandValidator_ShouldHaveValidationError_WhenPhoneIsEmpty()
        {
            // Arrange
            var validator = new UpdateDriverCommandValidator();
            var driverDto = DriverDtoHelper.CreateDriverDto(Guid.NewGuid(), "John", "Doe", "john.doe@example.com", "123456789", null, "some-token");
            var command = new UpdateDriverCommand(driverDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Driver.Phone).WithErrorMessage("Phone is required");
        }

        [Fact]
        public void UpdateDriverCommandValidator_ShouldHaveValidationError_WhenEmailIsEmpty()
        {
            // Arrange
            var validator = new UpdateDriverCommandValidator();
            var driverDto = DriverDtoHelper.CreateDriverDto(Guid.NewGuid(), "John", "Doe", null, "123456789", "04121234567", "some-token");
            var command = new UpdateDriverCommand(driverDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Driver.Email).WithErrorMessage("Email is required");
        }

        [Fact]
        public void UpdateDriverCommandValidator_ShouldHaveValidationError_WhenDniNumberIsEmpty()
        {
            // Arrange
            var validator = new UpdateDriverCommandValidator();
            var driverDto = DriverDtoHelper.CreateDriverDto(Guid.NewGuid(), "John", "Doe", "john.doe@example.com", null, "04121234567", "some-token");
            var command = new UpdateDriverCommand(driverDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Driver.Dni.Number).WithErrorMessage("Dni number is required");
        }

        [Fact]
        public void UpdateDriverCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new UpdateDriverCommandValidator();
            var driverDto = DriverDtoHelper.CreateDriverDto(Guid.NewGuid(), "John", "Doe", "john.doe@example.com", "123456789", "04121234567", "some-token");
            var command = new UpdateDriverCommand(driverDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.Id);
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.Name.FirstName);
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.Name.LastName);
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.Phone);
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.Email);
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.Dni.Number);
        }
    }
}



