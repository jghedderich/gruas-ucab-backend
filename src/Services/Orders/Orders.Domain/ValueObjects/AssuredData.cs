namespace Orders.Domain.ValueObjects;

public record AssuredData // CLIENTE
{
    public string Name { get; } = default!;
    public string ContactNumber { get; } = default!;

    private AssuredData(string name, string contactNumber)
    {
        Name = name;
        ContactNumber = contactNumber;
    }

    public static AssuredData Of(string name, string contactNumber)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(contactNumber);

        return new AssuredData(name, contactNumber);
    }
}
