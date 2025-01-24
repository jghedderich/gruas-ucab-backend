using System.Diagnostics.CodeAnalysis;
using Providers.API.Endpoints.Drivers;
using Providers.Application.Vehicles.Queries.GetVehicleById;

namespace Providers.API.Endpoints.Vehicles;

public record GetVehicleByIdResponse(VehicleDto Vehicle);

[ExcludeFromCodeCoverage]
public class GetVehicleById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/vehicles/{vehicleId}", async (Guid vehicleId, ISender sender) =>
        {
            var result = await sender.Send(new GetVehicleByIdQuery(vehicleId));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<GetVehicleByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetVehicleById")
        .Produces<GetDriverByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Vehicles By Id")
        .WithDescription("Get Vehicles By Id")
        .RequireAuthorization();
    }
}
