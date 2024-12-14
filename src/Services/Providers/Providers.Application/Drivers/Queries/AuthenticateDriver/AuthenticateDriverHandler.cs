
using Drivers.Application.Exceptions;
using Providers.Application.Extensions;

namespace Drivers.Application.Drivers.Queries.AuthenticateDriver;

public class AuthenticateDriverHandler(IApplicationDbContext dbContext)
    : IQueryHandler<AuthenticateDriverQuery, AuthenticateDriverResult>
{
    public async Task<AuthenticateDriverResult> Handle(AuthenticateDriverQuery query, CancellationToken cancellationToken)
    {
        Driver driver = await dbContext.Drivers
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Email.Equals(query.Email) && o.Password.Equals(query.Password), cancellationToken)
            ?? throw new DriverAuthenticationException(query.Email.Value);

        var driverDto = driver.ToDriverDto();
        return new AuthenticateDriverResult(driverDto);
    }
}
