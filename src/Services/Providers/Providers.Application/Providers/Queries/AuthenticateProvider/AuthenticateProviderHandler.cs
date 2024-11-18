using Providers.Application.Extensions;

namespace Providers.Application.Providers.Queries.AuthenticateProvider;

public class AuthenticateProviderHandler(IApplicationDbContext dbContext)
    : IQueryHandler<AuthenticateProviderQuery, AuthenticateProviderResult>
{
    public async Task<AuthenticateProviderResult> Handle(AuthenticateProviderQuery query, CancellationToken cancellationToken)
    {
        Provider provider = await dbContext.Providers
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Email.Equals(query.Email) && o.Password.Equals(query.Password), cancellationToken)
            ?? throw new ProviderAuthenticationException(query.Email.Value);

        var providerDto = provider.ToProviderDto();
        return new AuthenticateProviderResult(providerDto);
    }
}