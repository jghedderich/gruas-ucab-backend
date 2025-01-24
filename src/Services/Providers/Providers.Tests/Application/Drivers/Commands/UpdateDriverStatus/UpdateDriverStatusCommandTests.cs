using FluentAssertions;
using FluentValidation.TestHelper;
using Providers.Application.Drivers.Commands.UpdateDriverStatus;
using Providers.Application.Dtos;
using Xunit;

namespace Providers.Tests.Application.Drivers.Commands.UpdateDriverStatus
{
    public class UpdateDriverStatusCommandTests
    {
        [Fact]
        public void UpdateDriverStatusCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var updateStatusDto = new UpdateStatusDto(Guid.NewGuid(), "Available", null);

            // Act
            var command = new UpdateDriverStatusCommand(updateStatusDto);

            // Assert
            command.Driver.Should().Be(updateStatusDto);
        }

        [Fact]
        public void UpdateDriverStatusResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new UpdateDriverStatusResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }

        [Fact]
        public void UpdateDriverStatusCommandValidator_ShouldHaveValidationError_WhenIdIsEmpty()
        {
            // Arrange
            var validator = new UpdateDriverStatusCommandValidator();
            var updateStatusDto = new UpdateStatusDto(Guid.Empty, "Available", null);
            var command = new UpdateDriverStatusCommand(updateStatusDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Driver.Id).WithErrorMessage("Id is required");
        }

        [Fact]
        public void UpdateDriverStatusCommandValidator_ShouldHaveValidationError_WhenStatusIsEmpty()
        {
            // Arrange
            var validator = new UpdateDriverStatusCommandValidator();
            var updateStatusDto = new UpdateStatusDto(Guid.NewGuid(), null, null);
            var command = new UpdateDriverStatusCommand(updateStatusDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Driver.Status).WithErrorMessage("Status is required");
        }

        [Fact]
        public void UpdateDriverStatusCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new UpdateDriverStatusCommandValidator();
            var updateStatusDto = new UpdateStatusDto(Guid.NewGuid(), "Available", null);
            var command = new UpdateDriverStatusCommand(updateStatusDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.Id);
            result.ShouldNotHaveValidationErrorFor(x => x.Driver.Status);
        }
    }
}




