using Providers.Application.Drivers.Queries.GetDriverById;

namespace Providers.API.Endpoints.Drivers;

public record GetDriverByIdResponse(DriverDto Driver);
public class GetDriverById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/drivers/{driverId}", async (Guid driverId, ISender sender) =>
        {
            var result = await sender.Send(new GetDriverByIdQuery(driverId));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<GetDriverByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetDriverById")
        .Produces<GetDriverByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Drivers By Id")
        .WithDescription("Get Drivers By Id");
    }
}
