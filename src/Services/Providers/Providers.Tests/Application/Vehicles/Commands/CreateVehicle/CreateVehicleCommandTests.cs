using FluentAssertions;
using FluentValidation.TestHelper;
using Providers.Application.Vehicles.Commands.CreateVehicle;

namespace Providers.Tests.Application.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommandTests
    {
        [Fact]
        public void CreateVehicleCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var vehicleDto = VehicleDtoHelper.CreateVehicleDto(
                Guid.NewGuid(), Guid.NewGuid(), "Car", "Toyota", "Corolla", 2020, "ABC123", "Red", true);

            // Act
            var command = new CreateVehicleCommand(vehicleDto);

            // Assert
            command.Vehicle.Should().Be(vehicleDto);
        }

        [Fact]
        public void CreateVehicleResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var result = new CreateVehicleResult(id);

            // Assert
            result.Id.Should().Be(id);
        }

        [Fact]
        public void CreateVehicleCommandValidator_ShouldHaveValidationError_WhenTypeIsEmpty()
        {
            // Arrange
            var validator = new CreateVehicleCommandValidator();
            var vehicleDto = VehicleDtoHelper.CreateVehicleDto(
                Guid.NewGuid(), Guid.NewGuid(), null, "Toyota", "Corolla", 2020, "ABC123", "Red", true);
            var command = new CreateVehicleCommand(vehicleDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Vehicle.Type).WithErrorMessage("Type is required");
        }

        [Fact]
        public void CreateVehicleCommandValidator_ShouldHaveValidationError_WhenBrandIsEmpty()
        {
            // Arrange
            var validator = new CreateVehicleCommandValidator();
            var vehicleDto = VehicleDtoHelper.CreateVehicleDto(
                Guid.NewGuid(), Guid.NewGuid(), "Car", null, "Corolla", 2020, "ABC123", "Red", true);
            var command = new CreateVehicleCommand(vehicleDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Vehicle.Brand).WithErrorMessage("Brand is required");
        }

        [Fact]
        public void CreateVehicleCommandValidator_ShouldHaveValidationError_WhenModelIsEmpty()
        {
            // Arrange
            var validator = new CreateVehicleCommandValidator();
            var vehicleDto = VehicleDtoHelper.CreateVehicleDto(
                Guid.NewGuid(), Guid.NewGuid(), "Car", "Toyota", null, 2020, "ABC123", "Red", true);
            var command = new CreateVehicleCommand(vehicleDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Vehicle.Model).WithErrorMessage("Model is required");
        }

        [Fact]
        public void CreateVehicleCommandValidator_ShouldHaveValidationError_WhenYearIsEmpty()
        {
            // Arrange
            var validator = new CreateVehicleCommandValidator();
            var vehicleDto = VehicleDtoHelper.CreateVehicleDto(
                Guid.NewGuid(), Guid.NewGuid(), "Car", "Toyota", "Corolla", 0, "ABC123", "Red", true);
            var command = new CreateVehicleCommand(vehicleDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Vehicle.Year).WithErrorMessage("Year is required");
        }

        [Fact]
        public void CreateVehicleCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new CreateVehicleCommandValidator();
            var vehicleDto = VehicleDtoHelper.CreateVehicleDto(
                Guid.NewGuid(), Guid.NewGuid(), "Car", "Toyota", "Corolla", 2020, "ABC123", "Red", true);
            var command = new CreateVehicleCommand(vehicleDto);

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
