using Orders.Application.Dtos;
using Orders.Application.Orders.Commands.OrderProgress;

namespace Orders.API.Endpoints.Orders;

public record UpdateOrderProgressRequest(OrderProgressDto Order);
public record UpdateOrderProgressResponse(bool IsSuccess, string Status);

public class UpdateOrderProgress : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/orders/progress", async (UpdateOrderProgressRequest request, ISender sender) =>
        {
            var command = request.Adapt<OrderProgressCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateOrderProgressResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateOrderProgress")
        .Produces<UpdateOrderProgressResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Order Progress")
        .WithDescription("Update Order Progress")
        .RequireAuthorization();
    }
}
