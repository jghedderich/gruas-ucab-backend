namespace Drivers.Application.Exceptions;

public class DriverAuthenticationException : Exception
{
    public DriverAuthenticationException(string email)
        : base($"Authentication failed for driver with email: {email}")
    {
    }
}
