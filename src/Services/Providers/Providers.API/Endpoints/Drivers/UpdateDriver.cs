using Providers.Application.Drivers.Commands.UpdateDriver;

namespace Providers.API.Endpoints.Drivers;

public record UpdateDriverRequest(DriverDto Driver);

public record UpdateDriverResponse(bool IsSuccess);

public class UpdateDriver : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/drivers", async (UpdateDriverRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateDriverCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateDriverResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateDriver")
        .Produces<UpdateDriverResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Driver")
        .WithDescription("Update Driver")
        .RequireAuthorization();
    }
}
