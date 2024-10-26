using Providers.Application.Providers.Commands.CreateProvider;

namespace Providers.API.Endpoints;

public record CreateProviderRequest(ProviderDto Provider);
public record CreateProviderResponse(Guid Id);

public class CreateProvider : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/providers", async (CreateProviderRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProviderCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateProviderResponse>();

            return Results.Created($"/providers/{response.Id}", response);
        })
        .WithName("CreateProvider")
        .Produces<CreateProviderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Provider")
        .WithDescription("Create Provider");
    }

}
