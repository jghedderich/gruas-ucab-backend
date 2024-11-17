using System;

namespace Admin.Domain.ValueObjects;

public class RateName
{
    public string Value { get; }

    private RateName(string value) 
    {
        Value = value;
    }

    public static RateName Create(string value) 
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
        {
            throw new ArgumentException("El nombre de la tarifa no puede estar vacío y debe tener un máximo de 100 caracteres.");
        }

        return new RateName(value); 
    }

    public override bool Equals(object? obj)
    {
        if (obj is not RateName other) return false;
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
