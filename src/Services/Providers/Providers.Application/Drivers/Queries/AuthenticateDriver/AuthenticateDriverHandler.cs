
using BuildingBlocks.Exceptions;
using BuildingBlocks.Hashing;
using BuildingBlocks.Jwt;
using Drivers.Application.Drivers.Queries.AuthenticateDriver;
using Providers.Application.Extensions;
using System.Security.Authentication;

namespace Providers.Application.Drivers.Queries.AuthenticateDriver;

public class AuthenticateDriverHandler(IApplicationDbContext dbContext, IPasswordHasher passwordHasher, TokenProvider tokenProvider)
    : IQueryHandler<AuthenticateDriverQuery, AuthenticateDriverResult>
{
    public async Task<AuthenticateDriverResult> Handle(AuthenticateDriverQuery query, CancellationToken cancellationToken)
    {
        Driver driver = await dbContext.Drivers
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Email.Equals(query.Email), cancellationToken)
            ?? throw new NotFoundException($"Driver with email: {query.Email} was not found");

        bool verified = passwordHasher.Verify(query.Password.Value, driver.Password.Value);

        if (!verified)
        {
            throw new InvalidCredentialException();
        }

        driver.UpdateToken(query.Token);

        dbContext.Drivers.Update(driver);
        await dbContext.SaveChangesAsync(cancellationToken);

        var driverDto = driver.ToDriverDto();

        var token = tokenProvider.Create(driver.Id, "driver");
        return new AuthenticateDriverResult(driverDto, token);
    }

    public static void UpdateDriverToken(Driver driver, string token)
    {
        driver.UpdateToken(token);
    }
}
