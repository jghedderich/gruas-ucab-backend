using Orders.Application.Dtos;
using Orders.Application.Operators.Commands.UpdateOperator;

namespace Orders.API.Endpoints.Operators;

public record UpdateOperatorRequest(OperatorDto Operator);

public record UpdateOperatorResponse(bool IsSuccess);

public class UpdateOperator : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/operators", async (UpdateOperatorRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateOperatorCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateOperatorResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateOperator")
        .Produces<UpdateOperatorResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Operator")
        .WithDescription("Update Operator");
    }
}