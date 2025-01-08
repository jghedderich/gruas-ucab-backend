using Admin.Application.Administrators.Commands.CreateAdministrator;

namespace Admin.API.Endpoints;

public record CreateAdministratorRequest(AdministratorDto Administrator);
public record CreateAdministratorResponse(Guid Id);

public class CreateAdministrator : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/administrators", async (CreateAdministratorRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateAdministratorCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateAdministratorResponse>();

            return Results.Created($"/administrators/{response.Id}", response);
        })
        .WithName("CreateAdministrator")
        .Produces<CreateAdministratorResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Administrator")
        .WithDescription("Create Administrator")
        .RequireAuthorization();
    }
}
