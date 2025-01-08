using Admin.Application.Extensions;
using BuildingBlocks.Exceptions;
using BuildingBlocks.Hashing;
using BuildingBlocks.Jwt;
using System.Security.Authentication;

namespace Admin.Application.Administrators.Queries.AuthenticateAdmin;

public class AuthenticateAdminHandler(IApplicationDbContext dbContext, IPasswordHasher passwordHasher, TokenProvider tokenProvider)
    : IQueryHandler<AuthenticateAdminQuery, AuthenticateAdminResult>
{
    public async Task<AuthenticateAdminResult> Handle(AuthenticateAdminQuery query, CancellationToken cancellationToken)
    {
        Administrator admin = await dbContext.Administrators
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Email.Equals(query.Email), cancellationToken)
            ?? throw new NotFoundException($"Admin with email: {query.Email} was not found");

        bool verified = passwordHasher.Verify(query.Password.Value, admin.Password.Value);
        if (!verified)
        {
            throw new InvalidCredentialException();
        }

        var adminDto = admin.ToAdministratorDto();
        var token = tokenProvider.Create(admin.Id, "administrator");
        return new AuthenticateAdminResult(adminDto, token);
    }
}