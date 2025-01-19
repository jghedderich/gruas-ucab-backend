using System.Diagnostics.CodeAnalysis;
using Admin.Application.Departments.Queries.GetDepartmentById;

namespace Admin.API.Endpoints;

public record GetDepartmentByIdResponse(DepartmentDto Department);

[ExcludeFromCodeCoverage]
public class GetDepartmentById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/departments/{departmentId}", async (Guid departmentId, ISender sender) =>
        {
            var result = await sender.Send(new GetDepartmentByIdQuery(departmentId));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<GetDepartmentByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetDepartmentById")
        .Produces<GetDepartmentByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Department By Id")
        .WithDescription("Get Department By Id")
        .RequireAuthorization();
    }
}
