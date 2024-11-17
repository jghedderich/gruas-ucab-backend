using System;

namespace Admin.Domain.ValueObjects;

public class RateDescription
{
    public string Value { get; }

    private RateDescription(string value) 
    {
        Value = value;
    }

    public static RateDescription Create(string value) 
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 200)
        {
            throw new ArgumentException("La descripción de la tarifa no puede estar vacía y debe tener un máximo de 200 caracteres.");
        }

        return new RateDescription(value); 
    }

    public override bool Equals(object? obj)
    {
        if (obj is not RateDescription other) return false;
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
