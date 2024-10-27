using Providers.Application.Drivers.Commands.CreateDriver;

namespace Providers.API.Endpoints;

public record CreateDriverRequest(DriverDto Driver);

public record CreateDriverResponse(Guid Id);

public class CreateDriver : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/drivers", async (CreateDriverRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateDriverCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateDriverResponse>();

            return Results.Created($"/drivers/{response.Id}", response);
        })
        .WithName("CreateDriver")
        .Produces<CreateDriverResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Driver")
        .WithDescription("Create Driver");
    }
}