using FluentAssertions;
using Providers.Domain.Events;
using Providers.Domain.Models;
using Providers.Domain.ValueObjects;

namespace Providers.Tests.Domain;

public class DriverEntityTests
{
    private readonly Driver _driver;

    public DriverEntityTests()
    {
        var id = Guid.NewGuid();
        var driverName = DriverName.Of("John", "Doe");
        var providerId = Guid.NewGuid();
        var vehicleId = Guid.NewGuid();
        var email = Email.Of("john.doe@gmail.com");
        var password = Password.Of("password123");
        var dni = Dni.Of(DniType.V, "87654321");
        var phone = Phone.Of("04123456789");

        _driver = Driver.Create(
            id,
            driverName,
            providerId,
            vehicleId,
            email,
            password,
            phone,
            dni,
            Status.Available);
    }

    [Fact]
    public void Driver_Create_ReturnsDriver()
    {
        // Act and Assert
        _driver.Should().NotBeNull();
        _driver.Email.Should().Be(Email.Of("john.doe@gmail.com"));
        _driver.Password.Should().Be(Password.Of("password123"));
        _driver.DomainEvents.Should().ContainSingle(e => e is DriverCreatedEvent);
    }

    [Fact]
    public void Driver_Update_UpdatesDriverProperties()
    {
        // Act
        var newProviderId = Guid.NewGuid();
        var newVehicleId = Guid.NewGuid();
        var newDriverName = DriverName.Of("Jane", "Smith");
        var newDni = Dni.Of(DniType.V, "12345678");
        var newPhone = Phone.Of("04129876543");

        _driver.Update(newVehicleId, newProviderId, newDriverName, newDni, newPhone);

        // Assert
        _driver.ProviderId.Should().Be(newProviderId);
        _driver.VehicleId.Should().Be(newVehicleId);
        _driver.DriverName.Should().Be(newDriverName);
        _driver.Phone.Should().Be(newPhone);

        _driver.DomainEvents.Should().ContainSingle(e => e is DriverUpdatedEvent);
    }

    [Fact]
    public void Driver_UpdatePassword_UpdatesPassword()
    {
        // Arrange
        Password NewPassword = Password.Of("NewPassword123");
        // Act
        _driver.UpdatePassword(NewPassword);

        // Assert
        _driver.Password.Should().Be(NewPassword);
        _driver.DomainEvents.Should().ContainSingle(e => e is DriverPasswordUpdatedEvent);
    }

    [Fact]
    public void Driver_UpdateStatus_UpdatesStatus()
    {
        // Arrange
        Status NewStatus = Status.Unavailable;

        // Act
        _driver.UpdateStatus(NewStatus);

        // Assert
        _driver.Status.Should().Be(NewStatus);
        _driver.DomainEvents.Should().ContainSingle(e => e is DriverStatusUpdatedEvent);
    }

    [Fact]
    public void Driver_UpdateLocation_UpdatesLocation()
    {
        // Arrange
        Location NewLocation = Location.Of("test1", "test2", Coordinates.Of("latitude1", "latidue2"), "City1", "State1", "1060");

        // Act
        _driver.UpdateLocation(NewLocation);

        // Assert
        _driver.Location.Should().Be(NewLocation);
        _driver.DomainEvents.Should().ContainSingle(e => e is DriverLocationUpdatedEvent);
    }
}
