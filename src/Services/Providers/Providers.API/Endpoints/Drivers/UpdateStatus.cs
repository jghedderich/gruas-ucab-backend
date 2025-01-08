using Providers.Application.Drivers.Commands.UpdateDriverStatus;

namespace Providers.API.Endpoints.Drivers;

public record UpdateDriverStatusRequest(UpdatePasswordDto Driver);
public record UpdateDriverStatusResponse(bool IsSuccess);

public class UpdateDriverStatus : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/drivers/status", async (UpdateDriverStatusRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateDriverStatusCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateDriverStatusResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateDriverStatus")
        .Produces<UpdateDriverStatusResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Driver Status")
        .WithDescription("Update Driver Status")
        .RequireAuthorization();
    }
}
