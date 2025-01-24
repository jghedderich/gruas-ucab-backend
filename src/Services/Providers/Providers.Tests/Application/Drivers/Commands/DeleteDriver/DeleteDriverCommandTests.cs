using FluentAssertions;
using FluentValidation.TestHelper;
using Providers.Application.Drivers.Commands.DeleteDriver;

namespace Providers.Tests.Application.Drivers.Commands.DeleteDriver
{
    public class DeleteDriverCommandTests
    {
        [Fact]
        public void DeleteDriverCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var driverId = Guid.NewGuid();

            // Act
            var command = new DeleteDriverCommand(driverId);

            // Assert
            command.DriverId.Should().Be(driverId);
        }

        [Fact]
        public void DeleteDriverResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new DeleteDriverResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }

        [Fact]
        public void DeleteDriverCommandValidator_ShouldHaveValidationError_WhenDriverIdIsEmpty()
        {
            // Arrange
            var validator = new DeleteDriverCommandValidator();
            var command = new DeleteDriverCommand(Guid.Empty);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.DriverId).WithErrorMessage("DriverId is required");
        }

        [Fact]
        public void DeleteDriverCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new DeleteDriverCommandValidator();
            var command = new DeleteDriverCommand(Guid.NewGuid());

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.DriverId);
        }
    }
}


