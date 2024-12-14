using Providers.Application.Providers.Queries.AuthenticateProvider;
using Providers.Domain.ValueObjects;

namespace Providers.API.Endpoints.Providers;

public record AuthenticateProviderRequest(string Email, string Password);
public record AuthenticateProviderResponse(ProviderDto Provider);

public class AuthenticateProvider : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/providers/authenticate", async (AuthenticateProviderRequest request, ISender sender) =>
        {
            var result = await sender.Send(new AuthenticateProviderQuery(Email.Of(request.Email), Password.Of(request.Password)));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<AuthenticateProviderResponse>();

            return Results.Ok(response);

        })
        .WithName("AuthenticateProvider")
        .Produces<AuthenticateProviderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status401Unauthorized)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Authenticate Provider")
        .WithDescription("Authenticate a provider using email and password");
    }
}