namespace Admin.Application.Exceptions;

public class AdministratorAuthenticationException : Exception
{
    public AdministratorAuthenticationException(string email)
        : base($"Authentication failed for admin with email: {email}")
    {
    }
}