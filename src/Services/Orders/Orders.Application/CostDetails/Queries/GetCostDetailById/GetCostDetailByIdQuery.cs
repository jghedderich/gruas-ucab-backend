namespace Orders.Application.CostDetails.Queries.GetCostDetailById;

public record GetCostDetailByIdQuery(Guid Id) : IQuery<GetCostDetailByIdResult>;

public record GetCostDetailByIdResult(CostDetailDto CostDetail);