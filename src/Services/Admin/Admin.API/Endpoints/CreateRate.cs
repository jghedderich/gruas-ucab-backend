using Admin.Application.Rates.Commands.CreateRate;

namespace Admin.API.Endpoints;

public record CreateRateRequest(RateDto Rate);
public record CreateRateResponse(Guid Id);

public class CreateRate : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/rates", async (CreateRateRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateRateCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateRateResponse>();

            return Results.Created($"/rates/{response.Id}", response);
        })
        .WithName("CreateRate")
        .Produces<CreateRateResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Rate")
        .WithDescription("Create Rate")
        .RequireAuthorization();
    }
}
