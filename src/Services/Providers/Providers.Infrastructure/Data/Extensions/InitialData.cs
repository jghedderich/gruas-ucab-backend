
using BuildingBlocks.Hashing;
using Providers.Domain.Models;
using Providers.Domain.ValueObjects;

namespace Providers.Infrastructure.Data.Extensions;

public class InitialData
{
    private static readonly List<Provider> _providers;

    static InitialData()
    {
        var passwordHasher = new PasswordHasher();

        _providers =
        [
            Provider.Create(
                Guid.NewGuid(),
                ProviderName.Of("John", "Truckerson"),
                Email.Of("johntruck@gmail.com"),
                Password.Of(passwordHasher.Hash("123456")),
                Phone.Of("04123349277"),
                Dni.Of(DniType.V, "29625837"),
                Company.Of("Gruas UCAB", "La empresa de gruas de la UCAB", "V-00006797", "Caracas", "Miranda")
            ),
            Provider.Create(
                Guid.NewGuid(),
                ProviderName.Of("Lisa", "Towferson"),
                Email.Of("lisatow@gmail.com"),
                Password.Of(passwordHasher.Hash("123456")),
                Phone.Of("04123349278"),
                Dni.Of(DniType.V, "29625838"),
                Company.Of("Bomba Trucks", "Super tow company", "V-00006778", "Maracaibo", "Zulia")
            )
        ];

        AddVehiclesToProvider(_providers[0], "Volvo", "Scania");
        AddVehiclesToProvider(_providers[1], "Mercedes-Benz", "MAN");

        // Adding specified drivers
        AddDriverToProvider(_providers[0], "Juan", "Hedderich", "jghedderich@proton.me");
        AddDriverToProvider(_providers[1], "Juancho", "Palacios", "jgh2748@gmail.com");
    }

    public static IEnumerable<Provider> Providers() => _providers;

    public static IEnumerable<Vehicle> Vehicles() => _providers.SelectMany(p => p.Vehicles);

    public static IEnumerable<Driver> Drivers() => _providers.SelectMany(p => p.Drivers);

    private static void AddVehiclesToProvider(Provider provider, string brand1, string brand2)
    {
        provider.AddVehicle(
            Guid.NewGuid(),
            VehicleType.Heavy,
            Brand.Of(brand1),
            Model.Of("Heavy Duty"),
            2022,
            "#000000",
            "ABC-123"

        );
        provider.AddVehicle(
            Guid.NewGuid(),
            VehicleType.Medium,
            Brand.Of(brand2),
            Model.Of("Cargo"),
            2021,
            "#5abbe8",
            "DEF-456"
        );
    }

    private static void AddDriverToProvider(Provider provider, string firstName, string lastName, string email)
    {
        var vehicles = provider.Vehicles.ToList();
        var passwordHasher = new PasswordHasher();

        provider.AddDriver(
            Guid.NewGuid(),
            DriverName.Of(firstName, lastName),
            provider.Id,
            vehicles[0].Id,
            Email.Of(email),
            Password.Of(passwordHasher.Hash("123456")),
            Phone.Of("04123349280"), // You can change this if needed
            Dni.Of(DniType.V, "29625840"), // Change as necessary
            Status.Available,
            Location.Of(address1: "La Castellana", address2: "", coordinates: Coordinates.Of("10.507365", "-66.859987"), city: "Caracas", state: "Miranda", zip: "1060")
        );
    }
}

