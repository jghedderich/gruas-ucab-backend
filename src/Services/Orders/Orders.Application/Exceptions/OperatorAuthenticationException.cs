namespace Orders.Application.Exceptions;

public class OperatorAuthenticationException : Exception
{
    public OperatorAuthenticationException(string email)
        : base($"Authentication failed for provider with email: {email}")
    {
    }
}
