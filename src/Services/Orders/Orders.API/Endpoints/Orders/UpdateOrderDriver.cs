using Orders.Application.Dtos;
using Orders.Application.Orders.Commands.UpdateOrderDriver;

namespace Orders.API.Endpoints.Orders;

public record UpdateOrderDriverRequest(UpdateDriverDto Order);

public record UpdateOrderDriverResponse(bool IsSuccess);

public class UpdateOrderDriver : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/orders/drivers", async (UpdateOrderDriverRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateOrderDriverCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateOrderDriverResponse>();

            Console.WriteLine(response);

            return Results.Ok(response);
        })
        .WithName("UpdateOrderDriver")
        .Produces<UpdateOrderDriverResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Order Driver")
        .WithDescription("Update Order Driver")
        .RequireAuthorization();
    }
}