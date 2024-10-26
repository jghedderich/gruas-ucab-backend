using System.Text.RegularExpressions;

namespace Providers.Domain.ValueObjects;

public record Email
{
    public string Value { get; } = default!;
    private Email(string value)
    {
        Value = value;
    }

    private static readonly Regex EmailRegex = new Regex(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static Email Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        if (!EmailRegex.IsMatch(value))
        {
            throw new ArgumentException("Invalid email format.", nameof(value));
        }

        return new Email(value);
    }
}
