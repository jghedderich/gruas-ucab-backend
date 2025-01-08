using Providers.Application.Drivers.Commands.DeleteDriver;

namespace Providers.API.Endpoints.Drivers;

public record DeleteDriverResponse(bool IsSuccess);

public class DeleteDriver : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/drivers/{id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteDriverCommand(Id));

            var response = result.Adapt<DeleteDriverResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteDriver")
        .Produces<DeleteDriverResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Driver")
        .WithDescription("Delete Driver")
        .RequireAuthorization();
    }
}
