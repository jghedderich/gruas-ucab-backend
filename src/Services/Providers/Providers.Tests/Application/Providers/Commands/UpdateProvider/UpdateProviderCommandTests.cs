using FluentAssertions;
using FluentValidation.TestHelper;
using Providers.Application.Providers.Commands.UpdateProvider;

namespace Providers.Tests.Application.Providers.Commands.UpdateProvider
{
    public class UpdateProviderCommandTests
    {
        [Fact]
        public void UpdateProviderCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var providerDto = ProviderDtoHelper.CreateProviderDto(
                Guid.NewGuid(), "John", "Doe", "04121234567", "john.doe@example.com", "password", "123456789",
                "CompanyName", "CompanyDescription", "RIF123", "State", "City", new List<VehicleDto>(), new List<DriverDto>(), true);

            // Act
            var command = new UpdateProviderCommand(providerDto);

            // Assert
            command.Provider.Should().Be(providerDto);
        }

        [Fact]
        public void UpdateProviderResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new UpdateProviderResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }

        [Fact]
        public void UpdateProviderCommandValidator_ShouldHaveValidationError_WhenPhoneIsEmpty()
        {
            // Arrange
            var validator = new UpdateProviderCommandValidator();
            var providerDto = ProviderDtoHelper.CreateProviderDto(
                Guid.NewGuid(), "John", "Doe", null, "john.doe@example.com", "password", "123456789",
                "CompanyName", "CompanyDescription", "RIF123", "State", "City", new List<VehicleDto>(), new List<DriverDto>(), true);
            var command = new UpdateProviderCommand(providerDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Provider.Phone).WithErrorMessage("Phone is required");
        }

        [Fact]
        public void UpdateProviderCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new UpdateProviderCommandValidator();
            var providerDto = ProviderDtoHelper.CreateProviderDto(
                Guid.NewGuid(), "John", "Doe", "04121234567", "john.doe@example.com", "password", "123456789",
                "CompanyName", "CompanyDescription", "RIF123", "State", "City", new List<VehicleDto>(), new List<DriverDto>(), true);
            var command = new UpdateProviderCommand(providerDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Provider.Name.FirstName);
            result.ShouldNotHaveValidationErrorFor(x => x.Provider.Name.LastName);
            result.ShouldNotHaveValidationErrorFor(x => x.Provider.Phone);
            result.ShouldNotHaveValidationErrorFor(x => x.Provider.Dni.Number);
        }
    }
}
