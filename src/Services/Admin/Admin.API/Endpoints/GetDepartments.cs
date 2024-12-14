using BuildingBlocks.Pagination;
using Admin.Application.Departments.Queries.GetDepartments;

namespace Admin.API.Endpoints;

public record GetDepartmentsResponse(PaginatedResult<DepartmentDto> Departments);

public class GetDepartments : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/departments", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetDepartmentsQuery(request));

            var response = result.Adapt<GetDepartmentsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetDepartments")
        .Produces<GetDepartmentsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Departments")
        .WithDescription("Retrieve a paginated list of departments");
    }
}
