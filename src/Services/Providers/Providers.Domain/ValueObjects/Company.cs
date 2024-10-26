namespace Providers.Domain.ValueObjects;

public record Company
{
    public string Name { get; } = default!;
    public string Description { get; } = default!;
    public string City { get; } = default!;
    public string State { get; } = default!;
    public string Rif { get; private set; } = default!;

    private Company(string name, string description, string rif, string city, string state)
    {
        Name = name;
        Description = description;
        Rif = rif;
        City = city;
        State = state;
    }

    public static Company Of(string name, string description, string rif, string city, string state)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentException.ThrowIfNullOrWhiteSpace(city);
        ArgumentException.ThrowIfNullOrWhiteSpace(state);
        ArgumentException.ThrowIfNullOrWhiteSpace(rif);

        return new Company(name, description, rif, city, state);
    }
}
