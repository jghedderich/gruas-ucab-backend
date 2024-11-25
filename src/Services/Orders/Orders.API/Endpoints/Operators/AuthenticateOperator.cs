using Orders.Application.Dtos;
using Orders.Application.Operators.Queries.AuthenticateOperator;
using Orders.Domain.ValueObjects;

namespace Orders.API.Endpoints.Operators;

public record AuthenticateOperatorRequest(string Email, string Password);
public record AuthenticateOperatorResponse(OperatorDto Operator);

public class AuthenticateOperator : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/operators/authenticate", async (AuthenticateOperatorRequest request, ISender sender) =>
        {
            var result = await sender.Send(new AuthenticateOperatorQuery(Email.Of(request.Email), Password.Of(request.Password)));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<AuthenticateOperatorResponse>();

            return Results.Ok(response);

        })
        .WithName("AuthenticateOperator")
        .Produces<AuthenticateOperatorResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status401Unauthorized)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Authenticate Operator")
        .WithDescription("Authenticate a operator using email and password");
    }
}