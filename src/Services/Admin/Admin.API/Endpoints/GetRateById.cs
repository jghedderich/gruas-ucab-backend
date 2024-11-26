using Admin.Application.Rates.Queries.GetRateById;

namespace Admin.API.Endpoints;

public record GetRateByIdResponse(RateDto Rate);

public class GetRateById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/rates/{rateId}", async (Guid rateId, ISender sender) =>
        {
            var result = await sender.Send(new GetRateByIdQuery(rateId));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<GetRateByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetRateById")
        .Produces<GetRateByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Rate By Id")
        .WithDescription("Get Rate By Id");
    }
}
