using Admin.Application.Administrators.Commands.UpdateAdministrator;



namespace Admin.API.Endpoints;

public record UpdateAdministratorRequest(AdministratorDto Administrator);
public record UpdateAdministratorResponse(bool IsSuccess);

public class UpdateAdministrator : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/administrators", async (UpdateAdministratorRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateAdministratorCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateAdministratorResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateAdministrator")
        .Produces<UpdateAdministratorResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Administrator")
        .WithDescription("Update Administrator")
        .RequireAuthorization();
    }
}
