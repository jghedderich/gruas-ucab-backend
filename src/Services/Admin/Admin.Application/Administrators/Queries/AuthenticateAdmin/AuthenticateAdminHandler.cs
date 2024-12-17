using Admin.Application.Extensions;

namespace Admin.Application.Administrators.Queries.AuthenticateAdmin;

public class AuthenticateAdminHandler(IApplicationDbContext dbContext)
    : IQueryHandler<AuthenticateAdminQuery, AuthenticateAdminResult>
{
    public async Task<AuthenticateAdminResult> Handle(AuthenticateAdminQuery query, CancellationToken cancellationToken)
    {
        Administrator admin = await dbContext.Administrators
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Email.Equals(query.Email) && o.Password.Equals(query.Password), cancellationToken)
            ?? throw new AdministratorAuthenticationException(query.Email.Value);

        var adminDto = admin.ToAdministratorDto();
        return new AuthenticateAdminResult(adminDto);
    }
}