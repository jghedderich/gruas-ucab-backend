using System.Text.RegularExpressions;

namespace Admin.Domain.ValueObjects;

public class Password
{
    public string Value { get; private set; }

    private Password(string value)
    {
        Value = value;
    }

    public static Password Create(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("La contraseña no puede estar vacía.", nameof(password));
        }

        return new Password(password);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Password other) return false;
        return Value == other.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return new string('*', Value.Length); 
    }
}
