using Admin.Application.Departments.Commands.DeleteDepartment;

namespace Admin.API.Endpoints;

public record DeleteDepartmentResponse(bool IsSuccess);

public class DeleteDepartment : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/departments/{id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteDepartmentCommand(Id));

            var response = result.Adapt<DeleteDepartmentResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteDepartment")
        .Produces<DeleteDepartmentResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Department")
        .WithDescription("Delete Department");
    }
}
