using BuildingBlocks.Pagination;
using Providers.Application.Providers.Queries.GetProviders;

namespace Providers.API.Endpoints;

public record GetProvidersResponse(PaginatedResult<ProviderDto> Providers);

public class GetProviders : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/providers", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetProvidersQuery(request));

            var response = result.Adapt<GetProvidersResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProviders")
        .Produces<GetProvidersResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Providers")
        .WithDescription("Get Providers");
    }
}
