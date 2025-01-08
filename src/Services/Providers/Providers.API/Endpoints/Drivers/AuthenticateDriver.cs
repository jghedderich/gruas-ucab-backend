using Drivers.Application.Drivers.Queries.AuthenticateDriver;
using Providers.Domain.ValueObjects;

namespace Drivers.API.Endpoints.Drivers;

public record AuthenticateDriverRequest(string Email, string Password, string Token);
public record AuthenticateDriverResponse(DriverDto Driver, string Token);

public class AuthenticateDriver : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/drivers/authenticate", async (AuthenticateDriverRequest request, ISender sender) =>
        {
            var result = await sender.Send(new AuthenticateDriverQuery(Email.Of(request.Email), Password.Of(request.Password), request.Token));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<AuthenticateDriverResponse>();

            return Results.Ok(response);

        })
        .WithName("AuthenticateDriver")
        .Produces<AuthenticateDriverResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status401Unauthorized)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Authenticate Driver")
        .WithDescription("Authenticate a driver using email and password");
    }
}
