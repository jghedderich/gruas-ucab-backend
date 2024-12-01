using Orders.Application.Dtos;
using Orders.Application.Operators.Queries.VerifyCode;
using Orders.Domain.ValueObjects;

namespace Orders.API.Endpoints.Operators;

public record VerifyCodeRequest(string Email, string Code);
public record VerifyCodeResponse(VerifyCodeDto VerifyDto);

public class VerifyCode : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/verify-code", async (VerifyCodeRequest request, ISender sender) =>
        {
            var result = await sender.Send(new VerifyCodeQuery(Email: Email.Of(request.Email), Code: request.Code));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<VerifyCodeResponse>();

            return Results.Ok(response);

        })
        .WithName("VerifyCode")
        .Produces<VerifyCodeResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status401Unauthorized)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Verify Provider Recovery Code")
        .WithDescription("Verify password recovery code");
    }
}
