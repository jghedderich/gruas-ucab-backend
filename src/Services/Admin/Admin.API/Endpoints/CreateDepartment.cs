using System.Diagnostics.CodeAnalysis;
using Admin.Application.Departament.Commands.CreateDepartament;

namespace Admin.API.Endpoints;

public record CreateDepartmentRequest(DepartmentDto Department);
public record CreateDepartmentResponse(Guid Id);

[ExcludeFromCodeCoverage]
public class CreateDepartment : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/departments", async (CreateDepartmentRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateDepartmentCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateDepartmentResponse>();

            return Results.Created($"/departments/{response.Id}", response);
        })
        .WithName("CreateDepartment")
        .Produces<CreateDepartmentResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Department")
        .WithDescription("Create Department")
        .RequireAuthorization();
    }
}
