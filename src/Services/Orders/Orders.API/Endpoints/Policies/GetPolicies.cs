using BuildingBlocks.Pagination;
using Orders.Application.Dtos;
using Orders.Application.Policies.Queries.GetPolicies;

namespace Orders.API.Endpoints.Policies;

public record GetPoliciesResponse(PaginatedResult<PolicyDto> Policies);

public class GetPolicies : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/policies", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetPoliciesQuery(request));

            var response = result.Adapt<GetPoliciesResponse>();

            return Results.Ok(response);
        })
        .WithName("GetPolicies")
        .Produces<GetPoliciesResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Policies")
        .WithDescription("Get Policies")
        .RequireAuthorization();
    }
}