using Orders.Application.Dtos;
using Orders.Application.Operators.Commands.CreateOperator;

namespace Orders.API.Endpoints.Operators;

public record CreateOperatorRequest(OperatorDto Operator);

public record CreateOperatorResponse(Guid Id);

public class CreateOperator : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/operators", async (CreateOperatorRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateOperatorCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateOperatorResponse>();

            return Results.Created($"/operators/{response.Id}", response);
        })
        .WithName("CreateOperator")
        .Produces<CreateOperatorResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Operator")
        .WithDescription("Create Operator")
        .RequireAuthorization();
    }
}