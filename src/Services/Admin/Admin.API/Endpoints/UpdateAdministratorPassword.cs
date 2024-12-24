using Admin.Application.Administrators.Commands.UpdateAdministratorPassword;

namespace Admin.API.Endpoints;

public record UpdateAdministratorPasswordRequest(UpdatePasswordDto Administrator);
public record UpdateAdministratorPasswordResponse(bool IsSuccess);

public class UpdateAdministratorPassword : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/administrators/password", async (UpdateAdministratorPasswordRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateAdministratorPasswordCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateAdministratorPasswordResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateAdministratorPassword")
        .Produces<UpdateAdministratorPasswordResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Administrator Password")
        .WithDescription("Update Administrator Password");
    }
}
