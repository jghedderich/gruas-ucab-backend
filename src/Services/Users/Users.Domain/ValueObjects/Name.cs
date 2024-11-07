
namespace Users.Domain.ValueObjects;

public record Name
{
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;
    private Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Name Of(string firstName, string lastName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
    
        return new Name(firstName, lastName);
    }
}
