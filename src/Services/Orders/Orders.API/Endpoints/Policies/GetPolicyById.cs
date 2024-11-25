using Orders.Application.Dtos;
using Orders.Application.Policies.Queries.GetPolicyById;

namespace Orders.API.Endpoints.Policies;

public record GetPolicyByIdResponse(PolicyDto Policy);

public class GetPolicyById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/policies/{policyId}", async (Guid policyId, ISender sender) =>
        {
            var result = await sender.Send(new GetPolicyByIdQuery(policyId));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<GetPolicyByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetPolicyById")
        .Produces<GetPolicyByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Policy By Id")
        .WithDescription("Get Policy By Id");
    }
}