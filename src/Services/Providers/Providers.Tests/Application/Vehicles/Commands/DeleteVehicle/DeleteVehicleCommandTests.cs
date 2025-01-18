using FluentAssertions;
using FluentValidation.TestHelper;
using Providers.Application.Vehicles.Commands.DeleteVehicle;

namespace Providers.Tests.Application.Vehicles.Commands.DeleteVehicle
{
    public class DeleteVehicleCommandTests
    {
        [Fact]
        public void DeleteVehicleCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var vehicleId = Guid.NewGuid();

            // Act
            var command = new DeleteVehicleCommand(vehicleId);

            // Assert
            command.VehicleId.Should().Be(vehicleId);
        }

        [Fact]
        public void DeleteVehicleResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new DeleteVehicleResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }

        [Fact]
        public void DeleteVehicleCommandValidator_ShouldHaveValidationError_WhenVehicleIdIsEmpty()
        {
            // Arrange
            var validator = new DeleteVehicleCommandValidator();
            var command = new DeleteVehicleCommand(Guid.Empty);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.VehicleId).WithErrorMessage("VehicleId is required");
        }

        [Fact]
        public void DeleteVehicleCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new DeleteVehicleCommandValidator();
            var command = new DeleteVehicleCommand(Guid.NewGuid());

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.VehicleId);
        }
    }
}

