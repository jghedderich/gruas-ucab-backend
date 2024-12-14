
namespace Orders.Domain.ValueObjects;

public record Coordinates
{
    public string Latitude { get; } = default!;
    public string Longitude { get; } = default!;

    private Coordinates(string latitude, string longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Coordinates Of(string  latitude, string longitude)
    {
        ArgumentException.ThrowIfNullOrEmpty(latitude);
        ArgumentException.ThrowIfNullOrEmpty(longitude);

        return new Coordinates(latitude, longitude);
    }
}
