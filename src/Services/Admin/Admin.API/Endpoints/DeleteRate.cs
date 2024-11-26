using Admin.Application.Rates.Commands.DeleteRate;

namespace Admin.API.Endpoints;

public record DeleteRateResponse(bool IsSuccess);

public class DeleteRate : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/rates/{id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteRateCommand(Id));

            var response = result.Adapt<DeleteRateResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteRate")
        .Produces<DeleteRateResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Rate")
        .WithDescription("Delete Rate");
    }
}
