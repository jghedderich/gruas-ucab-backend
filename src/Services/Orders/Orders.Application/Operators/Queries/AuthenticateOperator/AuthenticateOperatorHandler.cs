using Orders.Application.Exceptions;
using Orders.Application.Extensions;

namespace Orders.Application.Operators.Queries.AuthenticateOperator;

public class AuthenticateOperatorHandler(IApplicationDbContext dbContext)
    : IQueryHandler<AuthenticateOperatorQuery, AuthenticateOperatorResult>
{
    public async Task<AuthenticateOperatorResult> Handle(AuthenticateOperatorQuery query, CancellationToken cancellationToken)
    {
        Operator operatorn = await dbContext.Operators
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Email.Equals(query.Email) && o.Password.Equals(query.Password), cancellationToken)
            ?? throw new OperatorAuthenticationException(query.Email.Value);

        var operatorDto = operatorn.ToOperatorDto();
        return new AuthenticateOperatorResult(operatorDto);
    }
}

