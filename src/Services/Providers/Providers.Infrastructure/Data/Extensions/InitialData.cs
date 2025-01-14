using BuildingBlocks.Hashing;
using Providers.Domain.Models;
using Providers.Domain.ValueObjects;

namespace Providers.Infrastructure.Data.Extensions;

public class InitialData
{
    private static readonly List<Provider> _providers;
    private static readonly Random _random = new Random();

    static InitialData()
    {
        var passwordHasher = new PasswordHasher();

        _providers = new List<Provider>
        {
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
        };

        AddVehiclesToProvider(_providers[0], "Volvo", "Scania", "Kenworth", "Peterbilt", "Freightliner");
        AddVehiclesToProvider(_providers[1], "Mercedes-Benz", "MAN", "Hino", "Isuzu", "Mack");

        // Adding specified drivers
        AddDriverToProvider(_providers[0], "Juan", "Hedderich", "04123349280", "29625840");
        AddDriverToProvider(_providers[0], "Carlos", "Perez", "04123349281", "29625841");
        AddDriverToProvider(_providers[0], "Maria", "Gomez", "04123349282", "29625842");
        AddDriverToProvider(_providers[0], "Jose", "Martinez", "04123349283", "29625843");
        AddDriverToProvider(_providers[0], "Ana", "Lopez", "04123349284", "29625844");
        AddDriverToProvider(_providers[0], "Luis", "Rodriguez", "04123349285", "29625845");
        AddDriverToProvider(_providers[0], "Carmen", "Hernandez", "04123349286", "29625846");
        AddDriverToProvider(_providers[0], "Miguel", "Garcia", "04123349287", "29625847");
        AddDriverToProvider(_providers[0], "Laura", "Fernandez", "04123349288", "29625848");

        AddDriverToProvider(_providers[1], "Juancho", "Palacios", "04123349289", "29625849");
        AddDriverToProvider(_providers[1], "Pedro", "Sanchez", "04123349290", "29625850");
        AddDriverToProvider(_providers[1], "Lucia", "Ramirez", "04123349291", "29625851");
        AddDriverToProvider(_providers[1], "Rosa", "Diaz", "04123349292", "29625852");
        AddDriverToProvider(_providers[1], "Jorge", "Morales", "04123349293", "29625853");
        AddDriverToProvider(_providers[1], "Elena", "Vargas", "04123349294", "29625854");
    }

    public static IEnumerable<Provider> Providers() => _providers;

    public static IEnumerable<Vehicle> Vehicles() => _providers.SelectMany(p => p.Vehicles);

    public static IEnumerable<Driver> Drivers() => _providers.SelectMany(p => p.Drivers);

    private static void AddVehiclesToProvider(Provider provider, params string[] brands)
    {
        var models = new[] { "Heavy Duty", "Cargo", "T370", "389", "M2 106" };
        var colors = new[] { "#000000", "#5abbe8", "#ff0000", "#00ff00", "#0000ff" };
        var licensePlates = new[] { "ABC-123", "DEF-456", "GHI-789", "JKL-012", "MNO-345" };

        for (int i = 0; i < brands.Length; i++)
        {
            provider.AddVehicle(
                Guid.NewGuid(),
                VehicleType.Heavy,
                Brand.Of(brands[i]),
                Model.Of(models[i]),
                2022 - i,
                colors[i],
                licensePlates[i]
            );
        }
    }

    private static void AddDriverToProvider(Provider provider, string firstName, string lastName, string phone, string dniNumber)
    {
        var vehicles = provider.Vehicles.ToList();
        var passwordHasher = new PasswordHasher();
        var coordinates = GenerateRandomCoordinates();

        provider.AddDriver(
            Guid.NewGuid(),
            DriverName.Of(firstName, lastName),
            provider.Id,
            vehicles[0].Id,
            Email.Of("jghedderich@proton.me"),
            Password.Of(passwordHasher.Hash("123456")),
            Phone.Of(phone),
            Dni.Of(DniType.V, dniNumber),
            Status.Available,
            Location.Of(address1: "La Castellana", address2: "", coordinates: coordinates, city: "Caracas", state: "Miranda", zip: "1060")
        );
    }

    private static Coordinates GenerateRandomCoordinates()
    {
        // Bounding box for Caracas, Venezuela
        double minLat = 10.4806;
        double maxLat = 10.5086;
        double minLon = -66.9036;
        double maxLon = -66.8526;

        double latitude = minLat + (_random.NextDouble() * (maxLat - minLat));
        double longitude = minLon + (_random.NextDouble() * (maxLon - minLon));

        return Coordinates.Of(latitude.ToString("F6"), longitude.ToString("F6"));
    }
}

