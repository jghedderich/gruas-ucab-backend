

using Orders.Application.CostDetails.Commands.CreateCostDetail;
using Orders.Application.Dtos;

namespace Orders.API.Endpoints.CostDetails;

public record CreateCostDetailRequest(CostDetailDto CostDetail);

public record CreateCostDetailResponse(Guid Id);

public class CreateCostDetail : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/costdetails", async (CreateCostDetailRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateCostDetailCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateCostDetailResponse>();

            return Results.Created($"/costdetails/{response.Id}", response);
        })
        .WithName("CreateCostDetail")
        .Produces<CreateCostDetailResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create CostDetail")
        .WithDescription("Create CostDetail");
    }
}