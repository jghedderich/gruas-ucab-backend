using Orders.Application.CostDetails.Commands.UpdateCostDetailStatus;
using Orders.Application.Dtos;

namespace Orders.API.Endpoints.CostDetails;

public record UpdateCostDetailStatusRequest(UpdateStatusCostDetailDto CostDetail);
public record UpdateCostDetailStatusResponse(bool IsSuccess);

public class UpdateCostDetailStatus : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/costdetails/status", async (UpdateCostDetailStatusRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateCostDetailStatusCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateCostDetailStatusResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateCostDetailStatus")
        .Produces<UpdateCostDetailStatusResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update CostDetail Status")
        .WithDescription("Update CostDetail Status")
        .RequireAuthorization();
    }
}