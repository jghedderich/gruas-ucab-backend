using Orders.Application.Exceptions;
using Orders.Application.Extensions;
using BuildingBlocks.Exceptions;
using BuildingBlocks.Hashing;
using System.Security.Authentication;
using BuildingBlocks.Jwt;

namespace Orders.Application.Operators.Queries.AuthenticateOperator;

public class AuthenticateOperatorHandler(IApplicationDbContext dbContext, IPasswordHasher passwordHasher, TokenProvider tokenProvider)
    : IQueryHandler<AuthenticateOperatorQuery, AuthenticateOperatorResult>
{
    public async Task<AuthenticateOperatorResult> Handle(AuthenticateOperatorQuery query, CancellationToken cancellationToken)
    {
        Operator operatorn = await dbContext.Operators
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Email.Equals(query.Email), cancellationToken)
            ?? throw new NotFoundException($"Operator with email: {query.Email} was not found");

        bool verified = passwordHasher.Verify(query.Password.Value, operatorn.Password.Value);

        if (!verified)
        {
            throw new InvalidCredentialException();
        }

        var operatorDto = operatorn.ToOperatorDto();
        var token = tokenProvider.Create(operatorn.Id, "operator");
        return new AuthenticateOperatorResult(operatorDto, token);
    }
}

