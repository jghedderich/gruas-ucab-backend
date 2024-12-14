using Orders.Application.Operators.Queries.RequestCode;
using Orders.Domain.ValueObjects;

namespace Orders.API.Endpoints.Operators;

public record RequestCodeRequest(string Email, string Type);
public record RequestCodeResponse(bool IsSuccess);

public class RequestCode : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/request-code", async (RequestCodeRequest request, ISender sender) =>
        {
            var result = await sender.Send(new RequestCodeQuery(Email.Of(request.Email), request.Type));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<RequestCodeResponse>();

            return Results.Ok(response);

        })
        .WithName("RequestCode")
        .Produces<RequestCodeResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status401Unauthorized)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Request Code")
        .WithDescription("Request password recovery code with email");
    }
}
