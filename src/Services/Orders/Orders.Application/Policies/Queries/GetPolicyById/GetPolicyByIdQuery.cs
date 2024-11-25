namespace Orders.Application.Policies.Queries.GetPolicyById;

public record GetPolicyByIdQuery(Guid Id) : IQuery<GetPolicyByIdResult>;

public record GetPolicyByIdResult(PolicyDto Policy);