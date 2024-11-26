
using Admin.Application.Rates.Commands.UpdateRate;

namespace Admin.API.Endpoints;

public record UpdateRateRequest(RateDto Rate);
public record UpdateRateResponse(bool IsSuccess);

public class UpdateRate : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/rates", async (UpdateRateRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateRateCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateRateResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateRate")
        .Produces<UpdateRateResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Rate")
        .WithDescription("Update Rate");
    }
}
