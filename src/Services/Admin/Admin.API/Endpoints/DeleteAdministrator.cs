using Admin.Application.Administrators.Commands.DeleteAdministrator;

namespace Admin.API.Endpoints;

public record DeleteAdministratorResponse(bool IsSuccess);

public class DeleteAdministrator : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/administrators/{id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteAdministratorCommand(Id));

            var response = result.Adapt<DeleteAdministratorResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteAdministrator")
        .Produces<DeleteAdministratorResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Administrator")
        .WithDescription("Delete Administrator")
        .RequireAuthorization();
    }
}
