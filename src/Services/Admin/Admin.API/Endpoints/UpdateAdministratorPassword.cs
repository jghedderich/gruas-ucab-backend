
using Admin.Application.Administrators.Commands.UpdateAdministratorPassword;

namespace Admin.API.Endpoints;

public record UpdateAdmnistratorPasswordRequest(UpdatePasswordDto Administrator);
public record UpdateAdmnistratorPasswordResponse(bool IsSuccess);

public class UpdateAdmnistratorPassword : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/administrators/password", async (UpdateAdmnistratorPasswordRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateAdministratorPasswordCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateAdmnistratorPasswordResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateAdmnistratorPassword")
        .Produces<UpdateAdmnistratorPasswordResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Admnistrator Password")
        .WithDescription("Update Admnistrator Password");
    }
}
