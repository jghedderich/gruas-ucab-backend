using System.Diagnostics.CodeAnalysis;
using Providers.Application.Drivers.Commands.UpdateDriverPassword;

namespace Providers.API.Endpoints.Drivers;

public record UpdateDriverPasswordRequest(UpdatePasswordDto Driver);
public record UpdateDriverPasswordResponse(bool IsSuccess);

[ExcludeFromCodeCoverage]
public class UpdateDriverPassword : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/drivers/password", async (UpdateDriverPasswordRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateDriverPasswordCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateDriverPasswordResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateDriverPassword")
        .Produces<UpdateDriverPasswordResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Driver Password")
        .WithDescription("Update Driver Password");
    }
}
