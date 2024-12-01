using Providers.Application.Drivers.Commands.UpdateDriverLocation;

namespace Providers.API.Endpoints.Drivers;

public record UpdateDriverLocationRequest(UpdateLocationDto Location);
public record UpdateDriverLocationResponse(Guid Id, bool IsSuccess);

public class UpdateDriverLocation : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/drivers/location", async (UpdateDriverLocationRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateDriverLocationCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateDriverLocationResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateDriverLocation")
        .Produces<UpdateDriverLocationResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Driver Location")
        .WithDescription("Update Driver Location");
    }
}
