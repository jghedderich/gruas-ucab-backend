using BuildingBlocks.Pagination;
using Orders.Application.CostDetails.Queries.GetCostDetails;
using Orders.Application.Dtos;

namespace Orders.API.Endpoints.CostDetails;

public record GetCostDetailsResponse(PaginatedResult<CostDetailDto> CostDetails);

public class GetCostDetails : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/costdetails", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetCostDetailsQuery(request));

            var response = result.Adapt<GetCostDetailsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetCostDetails")
        .Produces<GetCostDetailsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get CostDetails")
        .WithDescription("Get CostDetails")
        .RequireAuthorization();
    }
}