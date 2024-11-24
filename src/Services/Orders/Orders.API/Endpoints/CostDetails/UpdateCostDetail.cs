using Orders.Application.CostDetails.Commands.UpdateCostDetail;
using Orders.Application.Dtos;

namespace Orders.API.Endpoints.CostDetails;

public record UpdateCostDetailRequest(CostDetailDto CostDetail);

public record UpdateCostDetailResponse(bool IsSuccess);

public class UpdateCostDetail : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/costdetails", async (UpdateCostDetailRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateCostDetailCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateCostDetailResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateCostDetail")
        .Produces<UpdateCostDetailResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Cost Detail")
        .WithDescription("Update Cost Detail");
    }
}