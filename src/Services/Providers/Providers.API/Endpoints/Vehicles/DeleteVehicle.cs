using Providers.API.Endpoints.Drivers;
using Providers.Application.Vehicles.Commands.DeleteVehicle;

namespace Providers.API.Endpoints.Vehicles;

public record DeleteVehicleResponse(bool IsSuccess);

public class DeleteVehicle : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/vehicles/{id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteVehicleCommand(Id));

            var response = result.Adapt<DeleteVehicleResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteVehicle")
        .Produces<DeleteDriverResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Vehicle")
        .WithDescription("Delete Vehicle")
        .RequireAuthorization();
    }
}
