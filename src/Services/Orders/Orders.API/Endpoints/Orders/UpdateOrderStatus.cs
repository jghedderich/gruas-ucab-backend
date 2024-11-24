using Orders.Application.Dtos;
using Orders.Application.Orders.Commands.UpdateOrderStatus;

namespace Orders.API.Endpoints.Orders;

public record UpdateOrderStatusRequest(UpdateStatusDto Order);
public record UpdateOrderStatusResponse(bool IsSuccess);

public class UpdateOrderStatus : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/orders/status", async (UpdateOrderStatusRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateOrderStatusCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateOrderStatusResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateOrderStatus")
        .Produces<UpdateOrderStatusResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Order Status")
        .WithDescription("Update Order Status");
    }
}
