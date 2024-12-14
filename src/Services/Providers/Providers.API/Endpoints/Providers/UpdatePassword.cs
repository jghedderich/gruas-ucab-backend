using Providers.Application.Providers.Commands.UpdateProviderPassword;

namespace Providers.API.Endpoints.Providers;

public record UpdateProviderPasswordRequest(UpdatePasswordDto Provider);
public record UpdateProviderPasswordResponse(bool IsSuccess);

public class UpdateProviderPassword : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/providers/password", async (UpdateProviderPasswordRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateProviderPasswordCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateProviderPasswordResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateProviderPassword")
        .Produces<UpdateProviderPasswordResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Provider Password")
        .WithDescription("Update Provider Password");
    }
}
