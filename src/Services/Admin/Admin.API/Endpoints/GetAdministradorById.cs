using System.Diagnostics.CodeAnalysis;
using Admin.Application.Administrators.Queries.GetAdministratorById;

namespace Admin.API.Endpoints;

public record GetAdministratorByIdResponse(AdministratorDto Administrator);

[ExcludeFromCodeCoverage]
public class GetAdministratorById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/administrators/{administratorId}", async (Guid administratorId, ISender sender) =>
        {
            var result = await sender.Send(new GetAdministratorByIdQuery(administratorId));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<GetAdministratorByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetAdministratorById")
        .Produces<GetAdministratorByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Administrator By Id")
        .WithDescription("Get Administrator By Id")
        .RequireAuthorization();
    }
}

