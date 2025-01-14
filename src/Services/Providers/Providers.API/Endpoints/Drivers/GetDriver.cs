using BuildingBlocks.Pagination;
using Providers.Application.Drivers.Queries.GetDrivers;

namespace Providers.API.Endpoints.Drivers;

public record GetDriversResponse(PaginatedResult<DriverDto> Drivers);

public class GetDrivers : ICarterModule
{ 
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/drivers", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetDriversQuery(request));

            var response = result.Adapt<GetDriversResponse>();

            return Results.Ok(response);
        })
            .WithName("GetDrivers")
            .Produces<GetDriversResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Drivers")
            .WithDescription("Get Drivers")
            .RequireAuthorization();
    }
}

