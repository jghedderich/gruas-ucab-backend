using BuildingBlocks.Exceptions;
using BuildingBlocks.Hashing;
using BuildingBlocks.Jwt;
using Providers.Application.Extensions;
using System.Security.Authentication;

namespace Providers.Application.Providers.Queries.AuthenticateProvider;

public class AuthenticateProviderHandler(IApplicationDbContext dbContext, IPasswordHasher passwordHasher, TokenProvider tokenProvider)
    : IQueryHandler<AuthenticateProviderQuery, AuthenticateProviderResult>
{
    public async Task<AuthenticateProviderResult> Handle(AuthenticateProviderQuery query, CancellationToken cancellationToken)
    {
        Provider provider = await dbContext.Providers
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Email.Equals(query.Email), cancellationToken)
            ?? throw new NotFoundException($"Provider with email: {query.Email} was not found");

        bool verified = passwordHasher.Verify(query.Password.Value, provider.Password.Value);

        if (!verified) {
            throw new InvalidCredentialException();
        }
        
        var providerDto = provider.ToProviderDto();

        var token = tokenProvider.Create(provider.Id, "provider");
        return new AuthenticateProviderResult(providerDto, token);
    }
}

