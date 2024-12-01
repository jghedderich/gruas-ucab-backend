
namespace Providers.Domain.ValueObjects;

public record Location
{
    public string AddressLine1 { get; } = default!;
    public string? AddressLine2 { get; }
    public Coordinates Coordinates { get; } = default!;
    public string City { get; } = default!;
    public string State { get; } = default!;
    public string Zip { get; } = default!;

    public Location() { }

    private Location(string address1, string? address2, Coordinates coordinates, string city, string state, string zip) 
    {
        AddressLine1 = address1;
        AddressLine2 = address2;
        Coordinates = coordinates;
        City = city;
        State = state;
        Zip = zip;
    }

    public static Location Of(string address1, string? address2, Coordinates coordinates, string city, string state, string zip)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(address1);
        ArgumentException.ThrowIfNullOrWhiteSpace(city);
        ArgumentException.ThrowIfNullOrWhiteSpace(state);
        ArgumentException.ThrowIfNullOrWhiteSpace(zip);

        return new Location(address1,address2,coordinates, city,state,zip);
    }
}
