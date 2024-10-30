using Providers.Application.Vehicles.Commands.UpdateVehicle;

namespace Providers.API.Endpoints;

public record UpdateVehicleRequest(VehicleDto Vehicle);
public record UpdateVehicleResponse(bool IsSuccess);

public class UpdateVehicle : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/vehicles", async (UpdateVehicleRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateVehicleCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateVehicleResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateVehicle")
        .Produces<UpdateProviderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Vehicle")
        .WithDescription("Update Vehicle");
    }
}
