using Providers.Application.Vehicles.Commands.CreateVehicle;

namespace Providers.API.Endpoints;

public record CreateVehicleRequest(VehicleDto Vehicle);

public record CreateVehicleResponse(Guid Id);

public class CreateVehicle : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/vehicles", async (CreateVehicleRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateVehicleCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateVehicleResponse>();

            return Results.Created($"/vehicles/{response.Id}", response);
        })
        .WithName("CreateVehicle")
        .Produces<CreateDriverResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Vehicle")
        .WithDescription("Create Vehicle");
    }
}