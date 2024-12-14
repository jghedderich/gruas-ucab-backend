using Orders.Application.CostDetails.Queries.GetCostDetailById;
using Orders.Application.Dtos;
using Orders.Domain.Models;

namespace Orders.API.Endpoints.CostDetails;

public record GetCostDetailByIdResponse(CostDetailDto CostDetail);

public class GetCostDetailById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/costdetails/{costDetailId}", async (Guid costDetailId, ISender sender) =>
        {
            var result = await sender.Send(new GetCostDetailByIdQuery(costDetailId));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<GetCostDetailByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetCostDetailById")
        .Produces<GetCostDetailByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get CostDetail By Id")
        .WithDescription("Get CostDetail By Id");
    }
}