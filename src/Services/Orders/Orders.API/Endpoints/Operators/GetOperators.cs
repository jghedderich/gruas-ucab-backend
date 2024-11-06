using BuildingBlocks.Pagination;
using Orders.Application.Dtos;
using Orders.Application.Operators.Queries.GetOperators;

namespace Orders.API.Endpoints.Operators;

public record GetOperatorsResponse(PaginatedResult<OperatorDto> Operators);

public class GetOperators : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/operators", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetOperatorsQuery(request));

            var response = result.Adapt<GetOperatorsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetOperators")
        .Produces<GetOperatorsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Operators")
        .WithDescription("Get Operators");
    }
}