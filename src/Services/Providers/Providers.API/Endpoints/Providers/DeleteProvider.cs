using Providers.Application.Providers.Commands.DeleteProvider;

namespace Providers.API.Endpoints.Providers;

public record DeleteProviderResponse(bool IsSuccess);

public class DeleteProvider : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/providers/{id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteProviderCommand(Id));

            var response = result.Adapt<DeleteProviderResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteProvider")
        .Produces<DeleteProviderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Provider")
        .WithDescription("Delete Provider")
        .RequireAuthorization();
    }
}
