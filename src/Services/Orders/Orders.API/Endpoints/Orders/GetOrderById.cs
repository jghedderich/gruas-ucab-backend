using Orders.Application.Dtos;
using Orders.Application.Orders.Queries.GetOrderById;

namespace Orders.API.Endpoints.Orders;

public record GetOrderByIdResponse(OrderDto Order);

public class GetOrderById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/{orderId}", async (Guid orderId, ISender sender) =>
        {
            var result = await sender.Send(new GetOrderByIdQuery(orderId));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<GetOrderByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetOrderById")
        .Produces<GetOrderByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Order By Id")
        .WithDescription("Get Order By Id")
        .RequireAuthorization();
    }
}