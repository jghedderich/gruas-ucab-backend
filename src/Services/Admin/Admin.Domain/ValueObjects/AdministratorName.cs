using System.Text.RegularExpressions;

namespace Admin.Domain.ValueObjects;

public class AdministratorName
{
    public string Value { get; private set; }

   
    private AdministratorName(string value)
    {
        Value = value;
    }


    public static AdministratorName Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("El nombre del administrador no puede estar vacío.", nameof(name));
        }

        if (name.Length > 100)
        {
            throw new ArgumentException("El nombre del administrador no debe exceder los 100 caracteres.", nameof(name));
        }

        if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
        {
            throw new ArgumentException("El nombre del administrador solo puede contener letras y espacios.", nameof(name));
        }

        return new AdministratorName(name);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not AdministratorName other) return false;
        return Value == other.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value;
    }
}
