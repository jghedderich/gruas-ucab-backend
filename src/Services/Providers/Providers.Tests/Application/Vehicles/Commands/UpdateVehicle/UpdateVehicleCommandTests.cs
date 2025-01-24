using FluentAssertions;
using FluentValidation.TestHelper;
using Providers.Application.Vehicles.Commands.UpdateVehicle;

namespace Providers.Tests.Application.Vehicles.Commands.UpdateVehicle
{
    public class UpdateVehicleCommandTests
    {
        [Fact]
        public void UpdateVehicleCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var vehicleDto = VehicleDtoHelper.CreateVehicleDto(
                Guid.NewGuid(), Guid.NewGuid(), "Car", "Toyota", "Corolla", 2020, "ABC123", "Red", true);

            // Act
            var command = new UpdateVehicleCommand(vehicleDto);

            // Assert
            command.Vehicle.Should().Be(vehicleDto);
        }

        [Fact]
        public void UpdateVehicleResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new UpdateVehicleResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }

        [Fact]
        public void UpdateVehicleCommandValidator_ShouldHaveValidationError_WhenTypeIsEmpty()
        {
            // Arrange
            var validator = new UpdateVehicleCommandValidator();
            var vehicleDto = VehicleDtoHelper.CreateVehicleDto(
                Guid.NewGuid(), Guid.NewGuid(), null, "Toyota", "Corolla", 2020, "ABC123", "Red", true);
            var command = new UpdateVehicleCommand(vehicleDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Vehicle.Type).WithErrorMessage("Type is required");
        }

        [Fact]
        public void UpdateVehicleCommandValidator_ShouldHaveValidationError_WhenBrandIsEmpty()
        {
            // Arrange
            var validator = new UpdateVehicleCommandValidator();
            var vehicleDto = VehicleDtoHelper.CreateVehicleDto(
                Guid.NewGuid(), Guid.NewGuid(), "Car", null, "Corolla", 2020, "ABC123", "Red", true);
            var command = new UpdateVehicleCommand(vehicleDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Vehicle.Brand).WithErrorMessage("Brand is required");
        }

        [Fact]
        public void UpdateVehicleCommandValidator_ShouldHaveValidationError_WhenModelIsEmpty()
        {
            // Arrange
            var validator = new UpdateVehicleCommandValidator();
            var vehicleDto = VehicleDtoHelper.CreateVehicleDto(
                Guid.NewGuid(), Guid.NewGuid(), "Car", "Toyota", null, 2020, "ABC123", "Red", true);
            var command = new UpdateVehicleCommand(vehicleDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Vehicle.Model).WithErrorMessage("Model is required");
        }

        [Fact]
        public void UpdateVehicleCommandValidator_ShouldHaveValidationError_WhenYearIsEmpty()
        {
            // Arrange
            var validator = new UpdateVehicleCommandValidator();
            var vehicleDto = VehicleDtoHelper.CreateVehicleDto(
                Guid.NewGuid(), Guid.NewGuid(), "Car", "Toyota", "Corolla", 0, "ABC123", "Red", true);
            var command = new UpdateVehicleCommand(vehicleDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Vehicle.Year).WithErrorMessage("Year is required");
        }

        [Fact]
        public void UpdateVehicleCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new UpdateVehicleCommandValidator();
            var vehicleDto = VehicleDtoHelper.CreateVehicleDto(
                Guid.NewGuid(), Guid.NewGuid(), "Car", "Toyota", "Corolla", 2020, "ABC123", "Red", true);
            var command = new UpdateVehicleCommand(vehicleDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Vehicle.Type);
            result.ShouldNotHaveValidationErrorFor(x => x.Vehicle.Brand);
            result.ShouldNotHaveValidationErrorFor(x => x.Vehicle.Model);
            result.ShouldNotHaveValidationErrorFor(x => x.Vehicle.Year);
        }
    }
}

