using System.Diagnostics.CodeAnalysis;
using Providers.Application.Providers.Queries.GetProviderById;

namespace Providers.API.Endpoints.Providers;

public record GetProviderByIdResponse(ProviderDto Provider);

[ExcludeFromCodeCoverage]
public class GetProvidersById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/providers/{providerId}", async (Guid providerId, ISender sender) =>
        {
            var result = await sender.Send(new GetProviderByIdQuery(providerId));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<GetProviderByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProviderById")
        .Produces<GetProviderByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Providers By Id")
        .WithDescription("Get Providers By Id")
        .RequireAuthorization();
    }
}
