using Orders.Application.Operators.Commands.DeleteOperator;

namespace Orders.API.Endpoints.Operators;

public record DeleteOperatorResponse(bool IsSuccess);

public class DeleteOperator : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/operators/{id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteOperatorCommand(Id));

            var response = result.Adapt<DeleteOperatorResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteOperator")
        .Produces<DeleteOperatorResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Operator")
        .WithDescription("Delete Operator");
    }
}
