using BuildingBlocks.Pagination;
using Admin.Application.Administrators.Queries.GetAdministrators;
using System.Diagnostics.CodeAnalysis;

namespace Admin.API.Endpoints;

public record GetAdministratorsResponse(PaginatedResult<AdministratorDto> Administrators);

[ExcludeFromCodeCoverage]
public class GetAdministrators : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/administrators", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetAdministratorsQuery(request));

            var response = result.Adapt<GetAdministratorsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetAdministrators")
        .Produces<GetAdministratorsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Administrators")
        .WithDescription("Retrieve a paginated list of administrators")
        .RequireAuthorization();
    }
}
