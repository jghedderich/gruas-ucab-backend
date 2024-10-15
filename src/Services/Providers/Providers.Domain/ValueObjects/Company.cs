namespace Providers.Domain.ValueObjects;

public record Company
{
    public string Name { get; } = default!;
    public string Description { get; } = default!;
    public string City { get; } = default!;
    public string State { get; } = default!;
    public RIF Rif { get; private set; } = default!;

    protected Company()
    {
    }
    
    private Company(string name, string description, RIF rif, string city, string state)
    {
        Name = name;
        Description = description;
        Rif = rif;
        City = city;
        State = state;
    }

    public static Company Of(string name, string description, RIF rif, string city, string state)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentException.ThrowIfNullOrWhiteSpace(city);
        ArgumentException.ThrowIfNullOrWhiteSpace(state);

        return new Company(name, description, rif, city, state);
    }
}
