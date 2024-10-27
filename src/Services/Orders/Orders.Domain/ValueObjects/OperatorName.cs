namespace Orders.Domain.ValueObjects;

public record OperatorName
{
    private const int DefaultLength = 2;
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;

    private OperatorName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static OperatorName Of(string firstName, string lastName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);

        return new OperatorName(firstName, lastName);
    }
}
