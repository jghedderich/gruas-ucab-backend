using System;
using System.Text.RegularExpressions;

namespace Admin.Domain.ValueObjects;

public class DepartmentName
{
    public string Value { get; }

    private DepartmentName(string value)
    {
        Value = value;
    }

    public static DepartmentName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre del departamento no puede estar vacío.");

        if (!Regex.IsMatch(value, @"^[a-zA-Z\s]+$"))
            throw new ArgumentException("El nombre del departamento solo debe tener letras y espacios.");

        return new DepartmentName(value);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not DepartmentName other) return false;
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
