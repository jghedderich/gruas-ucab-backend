using Orders.Application.Dtos;
using Orders.Application.Policies.Commands.CreatePolicy;

namespace Orders.API.Endpoints.Policies;

public record CreatePolicyRequest(PolicyDto Policy);

public record CreatePolicyResponse(Guid Id);

public class CreatePolicy : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/policies", async (CreatePolicyRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreatePolicyCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreatePolicyResponse>();

            return Results.Created($"/policies/{response.Id}", response);
        })
        .WithName("CreatePolicy")
        .Produces<CreatePolicyResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Policy")
        .WithDescription("Create Policy");
    }
}