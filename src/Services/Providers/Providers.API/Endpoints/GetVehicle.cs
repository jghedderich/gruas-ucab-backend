using BuildingBlocks.Pagination;
using Providers.Application.Vehicles.Queries.GetVehicles;

namespace Providers.API.Endpoints;

public record GetVehiclesResponse(PaginatedResult<VehicleDto> Vehicles);

public class GetVehicles : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/vehicles", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetVehiclesQuery(request));

            var response = result.Adapt<GetVehiclesResponse>();

            return Results.Ok(response);
        })
            .WithName("GetVehicles")
            .Produces<GetDriversResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Vehicles")
            .WithDescription("Get Vehicles");
    }
}
