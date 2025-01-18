using FluentAssertions;
using FluentValidation.TestHelper;
using Providers.Application.Providers.Commands.CreateProvider;

namespace Providers.Tests.Application.Providers.Commands.CreateProvider
{
    public class CreateProviderCommandTests
    {
        [Fact]
        public void CreateProviderCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var providerDto = ProviderDtoHelper.CreateProviderDto(
                Guid.NewGuid(), "John", "Doe", "04121234567", "john.doe@example.com", "password", "123456789",
                "CompanyName", "CompanyDescription", "RIF123", "State", "City", new List<VehicleDto>(), new List<DriverDto>(), true);

            // Act
            var command = new CreateProviderCommand(providerDto);

            // Assert
            command.Provider.Should().Be(providerDto);
        }

        [Fact]
        public void CreateProviderResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var result = new CreateProviderResult(id);

            // Assert
            result.Id.Should().Be(id);
        }

        [Fact]
        public void CreateProviderCommandValidator_ShouldHaveValidationError_WhenPhoneIsEmpty()
        {
            // Arrange
            var validator = new CreateProviderCommandValidator();
            var providerDto = ProviderDtoHelper.CreateProviderDto(
                Guid.NewGuid(), "John", "Doe", null, "john.doe@example.com", "password", "123456789",
                "CompanyName", "CompanyDescription", "RIF123", "State", "City", new List<VehicleDto>(), new List<DriverDto>(), true);
            var command = new CreateProviderCommand(providerDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Provider.Phone).WithErrorMessage("Phone is required");
        }

        [Fact]
        public void CreateProviderCommandValidator_ShouldHaveValidationError_WhenEmailIsEmpty()
        {
            // Arrange
            var validator = new CreateProviderCommandValidator();
            var providerDto = ProviderDtoHelper.CreateProviderDto(
                Guid.NewGuid(), "John", "Doe", "04121234567", null, "password", "123456789",
                "CompanyName", "CompanyDescription", "RIF123", "State", "City", new List<VehicleDto>(), new List<DriverDto>(), true);
            var command = new CreateProviderCommand(providerDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Provider.Email).WithErrorMessage("Email is required");
        }

        [Fact]
        public void CreateProviderCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new CreateProviderCommandValidator();
            var providerDto = ProviderDtoHelper.CreateProviderDto(
                Guid.NewGuid(), "John", "Doe", "04121234567", "john.doe@example.com", "password", "123456789",
                "CompanyName", "CompanyDescription", "RIF123", "State", "City", new List<VehicleDto>(), new List<DriverDto>(), true);
            var command = new CreateProviderCommand(providerDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Provider.Name);
            result.ShouldNotHaveValidationErrorFor(x => x.Provider.Dni);
            result.ShouldNotHaveValidationErrorFor(x => x.Provider.Phone);
            result.ShouldNotHaveValidationErrorFor(x => x.Provider.Email);
        }
    }
}
