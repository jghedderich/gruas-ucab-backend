using Providers.Application.Providers.Commands.UpdateProvider;

namespace Providers.API.Endpoints;

public record UpdateProviderRequest(ProviderDto Provider);
public record UpdateProviderResponse(bool IsSuccess);

public class UpdateProvider : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/providers", async (UpdateProviderRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateProviderCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateProviderResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateProvider")
        .Produces<UpdateProviderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Provider")
        .WithDescription("Update Provider");
    }
}
