namespace Providers.Application.Providers.Queries.AuthenticateProvider;

public record AuthenticateProviderQuery(Email Email, Password Password)
    : IQuery<AuthenticateProviderResult>;

public record AuthenticateProviderResult(ProviderDto Provider);