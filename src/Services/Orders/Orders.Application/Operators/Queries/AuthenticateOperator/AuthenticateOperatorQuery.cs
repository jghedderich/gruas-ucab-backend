namespace Orders.Application.Operators.Queries.AuthenticateOperator;

public record AuthenticateOperatorQuery(Email Email, Password Password)
    : IQuery<AuthenticateOperatorResult>;

public record AuthenticateOperatorResult(OperatorDto Operator, string Token);
