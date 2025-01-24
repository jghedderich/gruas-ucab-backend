using System.Diagnostics.CodeAnalysis;
using Admin.Application.Administrators.Queries.VerifyCode;
using Admin.Domain.ValueObjects;

namespace Admin.API.Endpoints;

public record VerifyCodeRequest(string Email, string Code);
public record VerifyCodeResponse(VerifyCodeDto VerifyDto);

[ExcludeFromCodeCoverage]
public class VerifyCode : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/verify-code", async (VerifyCodeRequest request, ISender sender) =>
        {
            var result = await sender.Send(new VerifyCodeQuery(Email: Email.Create(request.Email), Code: request.Code));

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
        .WithSummary("Verify Admin Recovery Code")
        .WithDescription("Verify password recovery code");
    }
}
