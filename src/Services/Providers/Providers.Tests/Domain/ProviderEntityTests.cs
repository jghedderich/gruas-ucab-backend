using FluentAssertions;
using Providers.Domain.Events;
using Providers.Domain.Models;
using Providers.Domain.ValueObjects;

namespace Providers.Tests.Domain;

public class ProviderEntityTests
{
    private readonly Provider _provider;
    
    public ProviderEntityTests()
    {

        Guid id = Guid.NewGuid();
        ProviderName providerName = ProviderName.Of("testFirst", "lastTest");
        Email email = Email.Of("test@gmail.com");
        Password password = Password.Of("123456");
        Phone phone = Phone.Of("04123345785");
        Dni dni = Dni.Of(DniType.V, "12345678");
        Company company = Company.Of("testName", "testDesc", "testrif", "testCity", "testState");

        _provider = Provider.Create(id, providerName, email, password, phone, dni, company);
    }

    [Fact]
    public void Provider_Create_ReturnsValidProvider()
    {
        // Assert
        _provider.Should().NotBeNull();
        _provider.Id.Should().Be(_provider.Id);
        _provider.ProviderName.Should().Be(_provider.ProviderName);
        _provider.Email.Should().Be(_provider.Email);
        _provider.Phone.Should().Be(_provider.Phone);
        _provider.Company.Should().Be(_provider.Company);
        _provider.DomainEvents.Should().ContainSingle(e => e is ProviderCreatedEvent);
    }

    [Fact]
    public void Provider_Update_UpdatesPropertiesAndRaisesEvent()
    {
        // Arrange
        ProviderName newProviderName = ProviderName.Of("updatedFirst", "updatedLast");
        Company newCompany = Company.Of("updatedName", "updatedDesc", "updatedrif", "updatedCity", "updatedState");

        // Act
        _provider.Update(newProviderName, newCompany);

        // Assert
        _provider.ProviderName.Should().Be(newProviderName);
        _provider.Company.Should().Be(newCompany);

        _provider.DomainEvents.Should().ContainSingle(e => e is ProviderUpdatedEvent);
    }

    [Fact]
    public void Provider_AddDriver_AddsDriverToProvider()
    {
        // Arrange
        var id = Guid.NewGuid();
        var driverName = DriverName.Of("John", "Doe");
        var providerId = Guid.NewGuid();
        var vehicleId = Guid.NewGuid();
        var email = Email.Of("john.doe@gmail.com");
        var password = Password.Of("password123");
        var dni = Dni.Of(DniType.V, "87654321");
        var phone = Phone.Of("04123456789");
        var status = Status.Available;
        var location = Location.Of("testAddress1", "testAddress2", Coordinates.Of("0.12456", "14.545723"), "testCity", "testState", "1060" );

        // Act
        _provider.AddDriver(id, driverName, providerId, vehicleId, email, password, phone, dni, status, location);
        
        // Assert
        _provider.Drivers.Count().Should().Be(1);
        _provider.Drivers[0].DriverName.Should().Be(driverName);
    }

    [Fact]
    public void Provider_UpdatePassword_UpdatesPassword()
    {
        // Arrange
        Password NewPassword = Password.Of("newPassword");

        // Act
        _provider.UpdatePassword(NewPassword);

        // Assert
        _provider.Password.Should().Be(NewPassword);
    }


    [Fact]
    public void ProviderName_Of_ReturnsValidName()
    {
        // Arrange
        var firstName = "testFirstName";
        var lastName = "testLastName";

        // Act
        Action validAct = () => ProviderName.Of(firstName, lastName);
        Action invalidAct = () => ProviderName.Of("", "");

        // Assert
        invalidAct.Should().Throw<ArgumentException>();
        validAct.Should().NotThrow<ArgumentException>();
    }


    [Fact]
    public void Email_Of_ReturnsValidEmail()
    {
        // Arrange
        var invalidEmail = "emailtest.com";
        var validEmail = "email@test.com";

        // Act
        Action validAct = () => Email.Of(validEmail);
        Action invalidAct = () => Email.Of(invalidEmail);

        // Assert
        invalidAct.Should().Throw<ArgumentException>()
           .WithMessage("Invalid email format.*")
           .And.ParamName.Should().Be("value");

        validAct.Should().NotThrow<ArgumentException>();
    }

    [Fact]
    public void Company_Of_ReturnsValidCompany()
    {
        // Arrange
        string name = "TestName";
        string description = "TestDescription";
        string city = "TestCity";
        string state = "TestState";
        string rif = "testRif";

        // Act
        Action act = () => Company.Of(name, description, city, state, rif);
        Action invalidAct = () => Company.Of(name, description, city, "", rif);

        // Assert
        act.Should().NotThrow<ArgumentException>();
        invalidAct.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Phone_Of_ReturnsValidPhone()
    {
        // Arrange
        string invalidPhone = "123890";
        string validPhone = "12345678901";

        // Act
        Action act = () => Phone.Of(validPhone);
        Action invalidAct = () => Phone.Of(invalidPhone);

        // Assert
        act.Should().NotThrow<ArgumentException>();
        invalidAct.Should().Throw<ArgumentException>();
    }

}
