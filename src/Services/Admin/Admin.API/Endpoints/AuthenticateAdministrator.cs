
using Admin.Application.Administrators.Queries.AuthenticateAdmin;
using Admin.Domain.ValueObjects;

namespace Admin.API.Endpoints;

public record AuthenticateAdministratorRequest(string Email, string Password);
public record AuthenticateAdministratorResponse(AdministratorDto Administrator);

public class AuthenticateAdministrator : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Administrators/authenticate", async (AuthenticateAdministratorRequest request, ISender sender) =>
        {
            var result = await sender.Send(new AuthenticateAdminQuery(Email.Create(request.Email), Password.Create(request.Password)));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<AuthenticateAdministratorResponse>();

            return Results.Ok(response);

        })
        .WithName("AuthenticateAdministrator")
        .Produces<AuthenticateAdministratorResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status401Unauthorized)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Authenticate Administrator")
        .WithDescription("Authenticate a admin using email and password");
    }
}