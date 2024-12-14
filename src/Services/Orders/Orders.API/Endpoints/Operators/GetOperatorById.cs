using Orders.Application.Dtos;
using Orders.Application.Operators.Queries.GetOperatorById;

namespace Orders.API.Endpoints.Operators;

public record GetOperatorByIdResponse(OperatorDto Operator);

public class GetOperatorById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/operators/{operatorId}", async (Guid operatorId, ISender sender) =>
        {
            var result = await sender.Send(new GetOperatorByIdQuery(operatorId));

            if (result == null)
            {
                return Results.NotFound();
            }

            var response = result.Adapt<GetOperatorByIdResponse>();
            
            return Results.Ok(response);
        })
        .WithName("GetOperatorById")
        .Produces<GetOperatorByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Operator By Id")
        .WithDescription("Get Operator By Id");
    }
}