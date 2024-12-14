using BuildingBlocks.Pagination;
using Admin.Application.Rates.Queries.GetRates;


namespace Admin.API.Endpoints;

public record GetRatesResponse(PaginatedResult<RateDto> Rates);

public class GetRates : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/rates", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetRatesQuery(request));

            var response = result.Adapt<GetRatesResponse>();

            return Results.Ok(response);
        })
        .WithName("GetRates")
        .Produces<GetRatesResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Rates")
        .WithDescription("Retrieve a paginated list of rates");
    }
}
