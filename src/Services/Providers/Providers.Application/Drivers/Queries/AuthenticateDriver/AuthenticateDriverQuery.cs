namespace Drivers.Application.Drivers.Queries.AuthenticateDriver;

public record AuthenticateDriverQuery(Email Email, Password Password, string Token)
    : IQuery<AuthenticateDriverResult>;

public record AuthenticateDriverResult(DriverDto Driver);
