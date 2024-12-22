
using BuildingBlocks.Exceptions;
using BuildingBlocks.Hashing;
using Providers.Application.Extensions;
using System.Security.Authentication;

namespace Drivers.Application.Drivers.Queries.AuthenticateDriver;

public class AuthenticateDriverHandler(IApplicationDbContext dbContext, IPasswordHasher passwordHasher)
    : IQueryHandler<AuthenticateDriverQuery, AuthenticateDriverResult>
{
    public async Task<AuthenticateDriverResult> Handle(AuthenticateDriverQuery query, CancellationToken cancellationToken)
    {
        Driver driver = await dbContext.Drivers
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Email.Equals(query.Email), cancellationToken)
            ?? throw new NotFoundException($"Driver with email: {query.Email} was not found");

        bool verified = passwordHasher.Verify(query.Password.Value, driver.Password.Value);

        if (!verified) {
            throw new InvalidCredentialException();
        }

        var driverDto = driver.ToDriverDto();
        return new AuthenticateDriverResult(driverDto);
    }
}
