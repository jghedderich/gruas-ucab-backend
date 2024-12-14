namespace Users.Domain.ValueObjects;

public record Role
{
    private static readonly HashSet<string> ValidRoles =
    [
        "Admin",
        "Operator",
        "Driver",
        "Provider"
    ];

    public string Name { get; }

    private Role(string name)
    {
        Name = name;
    }

    public static Role Of(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Role name cannot be null or empty.", nameof(name));
        }

        if (!ValidRoles.Contains(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), $"Invalid role: {name}. Valid roles are: {string.Join(", ", ValidRoles)}");
        }

        return new Role(name);
    }
}