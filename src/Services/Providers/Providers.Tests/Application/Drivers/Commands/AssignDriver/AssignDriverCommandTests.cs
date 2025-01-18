using FluentAssertions;
using FluentValidation.TestHelper;
using Providers.Application.Drivers.Commands.AssignDriver;

namespace Providers.Tests.Application.Drivers.Commands.AssignDriver
{
    public class AssignDriverCommandTests
    {
        [Fact]
        public void AssignDriverCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var driverDto = new AssignDriverDto(Guid.NewGuid(), Guid.NewGuid());

            // Act
            var command = new AssignDriverCommand(driverDto);

            // Assert
            command.Driver.Should().Be(driverDto);
        }

        [Fact]
        public void AssignDriverResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new AssignDriverResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }

        [Fact]
        public void AssignDriverCommandValidator_ShouldHaveValidationError_WhenOrderIdIsEmpty()
        {
            // Arrange
            var validator = new AssignDriverCommandValidator();
            var command = new AssignDriverCommand(new AssignDriverDto(Guid.Empty, Guid.NewGuid()));

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Driver.OrderId).WithErrorMessage("OrderId is required");
        }

        [Fact]
        public void AssignDriverCommandValidator_ShouldHaveValidationError_WhenDriverIdIsEmpty()
        {
            // Arrange
            var validator = new AssignDriverCommandValidator();
            var command = new AssignDriverCommand(new AssignDriverDto(Guid.NewGuid(), Guid.Empty));

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Driver.DriverId).WithErrorMessage("DriverId is required");
        }

        [Fact]
        public void AssignDriverCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new AssignDriverCommandValidator();
            var command = new AssignDriverCommand(new AssignDriverDto(Guid.NewGuid(), Guid.NewGuid()));

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.OrderId);
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.DriverId);
        }
    }
}

