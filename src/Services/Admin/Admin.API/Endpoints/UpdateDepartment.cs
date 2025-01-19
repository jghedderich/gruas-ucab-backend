
using System.Diagnostics.CodeAnalysis;
using Admin.Application.Departament.Commands.UpdateDepartament;

namespace Admin.API.Endpoints;

public record UpdateDepartmentRequest(DepartmentDto Department);
public record UpdateDepartmentResponse(bool IsSuccess);

[ExcludeFromCodeCoverage]
public class UpdateDepartment : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/departments", async (UpdateDepartmentRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateDepartmentCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateDepartmentResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateDepartment")
        .Produces<UpdateDepartmentResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Department")
        .WithDescription("Update Department")
        .RequireAuthorization();
    }
}
