namespace Providers.Application.Exceptions;

public class ProviderAuthenticationException : Exception
{
    public ProviderAuthenticationException(string email)
        : base($"Authentication failed for provider with email: {email}")
    {
    }
}