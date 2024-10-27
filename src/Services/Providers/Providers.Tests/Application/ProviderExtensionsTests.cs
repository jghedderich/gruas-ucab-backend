
using FluentAssertions;
using Providers.Application.Extensions;
using Providers.Domain.Models;
using Providers.Domain.ValueObjects;

namespace Providers.Tests.Application;

public class ProviderExtensionsTests
{
    [Fact]
    public void ProviderExtensions_ToProviderDtoList_ReturnsProviderDtoLists()
    {
        // Arrange
        var providers = GenerateTestProviders(3);  // Generate a list of 3 providers

        // Act
        var providerDtos = ProviderExtensions.ToProviderDtoList(providers);

        // Assert
        providerDtos.Count().Should().Be(3);
    }

    private static List<Provider> GenerateTestProviders(int count)
    {
        var providers = new List<Provider>();

        for (int i = 0; i < count; i++)
        {
            Guid id = Guid.NewGuid();
            ProviderName providerName = ProviderName.Of($"FirstName{i}", $"LastName{i}");
            Email email = Email.Of($"test{i}@gmail.com");
            Phone phone = Phone.Of($"0412334578{i}");
            Dni dni = Dni.Of(DniType.V, $"12345678{i}");
            Company company = Company.Of($"CompanyName{i}", "Description", "RIF", "City", "State");

            // Create the provider and add it to the list
            var provider = Provider.Create(id, providerName, email, phone, dni, company);
            providers.Add(provider);
        }

        return providers;
    }
}
