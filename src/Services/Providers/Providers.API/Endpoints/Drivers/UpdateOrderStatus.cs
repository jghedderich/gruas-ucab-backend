using Providers.Application.Drivers.Commands.UpdateOrderStatus;

namespace Providers.API.Endpoints.Drivers;

public record UpdateOrderStatusRequest(UpdateOrderStatusDto Order);
public record UpdateOrderStatusResponse(Guid Id, bool IsSuccess);

public class UpdateOrderStatus : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/drivers/order", async (UpdateOrderStatusRequest request, ISender sender) =>
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
