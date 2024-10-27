using FluentAssertions;
using Providers.Domain.Events;
using Providers.Domain.Models;
using Providers.Domain.ValueObjects;

namespace Providers.Tests.Domain;

public class ProviderEntityTests
{
    [Fact]
    public void Provider_Create_ReturnsValidProvider()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        ProviderName providerName = ProviderName.Of("testFirst", "lastTest");
        Email email = Email.Of("test@gmail.com");
        Phone phone = Phone.Of("04123345785");
        Dni dni = Dni.Of(DniType.V, "12345678");
        Company company = Company.Of("testName", "testDesc", "testrif", "testCity", "testState");

        // Act
        var provider = Provider.Create(id, providerName, email, phone, dni, company);

        // Assert
        provider.Should().NotBeNull();
        provider.Id.Should().Be(id);
        provider.ProviderName.Should().Be(providerName);
        provider.Email.Should().Be(email);
        provider.Phone.Should().Be(phone);
        provider.Dni.Should().Be(dni);
        provider.Company.Should().Be(company);

        provider.DomainEvents.Should().ContainSingle(e => e is ProviderCreatedEvent);
    }

    [Fact]
    public void Provider_Update_UpdatesPropertiesAndRaisesEvent()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        ProviderName initialProviderName = ProviderName.Of("initialFirst", "initialLast");
        Email email = Email.Of("test@gmail.com");
        Phone phone = Phone.Of("04123345785");
        Dni dni = Dni.Of(DniType.V, "12345678");
        Company initialCompany = Company.Of("initialName", "initialDesc", "initialrif", "initialCity", "initialState");

        // Create the initial provider
        var provider = Provider.Create(id, initialProviderName, email, phone, dni, initialCompany);

        // New values for update
        ProviderName newProviderName = ProviderName.Of("updatedFirst", "updatedLast");
        Company newCompany = Company.Of("updatedName", "updatedDesc", "updatedrif", "updatedCity", "updatedState");

        // Act
        provider.Update(newProviderName, newCompany);

        // Assert
        provider.ProviderName.Should().Be(newProviderName);
        provider.Company.Should().Be(newCompany);

        provider.DomainEvents.Should().ContainSingle(e => e is ProviderUpdatedEvent);
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
