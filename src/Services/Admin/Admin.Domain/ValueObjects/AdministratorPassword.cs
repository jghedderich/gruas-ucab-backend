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

        if (password.Length < 8)
        {
            throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.", nameof(password));
        }

        if (!Regex.IsMatch(password, @"[A-Z]"))
        {
            throw new ArgumentException("La contraseña debe contener al menos una letra mayúscula.", nameof(password));
        }

        if (!Regex.IsMatch(password, @"[a-z]")) 
        {
            throw new ArgumentException("La contraseña debe contener al menos una letra minúscula.", nameof(password));
        }

        if (!Regex.IsMatch(password, @"\d")) 
        {
            throw new ArgumentException("La contraseña debe contener al menos un número.", nameof(password));
        }

        if (!Regex.IsMatch(password, @"[^\w\d\s]"))
        {
            throw new ArgumentException("La contraseña debe contener al menos un carácter especial.", nameof(password));
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
