namespace Orders.Domain.ValueObjects;

public record Address
{
    public string AddressLine1 { get; } = default!;
    public string AddressLine2 { get; } = default!;
    public string City { get; } = default!;
    public string State { get; } = default!;
    public string Zip { get; } = default!;

    public Address() { }

    private Address(string address1, string address2, string city, string state, string zip) 
    {
        AddressLine1 = address1;
        AddressLine2 = address2;
        City = city;
        State = state;
        Zip = zip;
    }

    public static Address Of(string address1, string address2, string city, string state, string zip)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(address1);
        ArgumentException.ThrowIfNullOrWhiteSpace(address2);
        ArgumentException.ThrowIfNullOrWhiteSpace(city);
        ArgumentException.ThrowIfNullOrWhiteSpace(state);
        ArgumentException.ThrowIfNullOrWhiteSpace(zip);

        return new Address(address1,address2,city,state,zip);
    }
}
