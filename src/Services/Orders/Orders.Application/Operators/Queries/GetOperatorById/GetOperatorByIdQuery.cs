
namespace Orders.Application.Operators.Queries.GetOperatorById;

public record GetOperatorByIdQuery(Guid Id) : IQuery<GetOperatorByIdResult>;

public record GetOperatorByIdResult(OperatorDto Operator);
