using Orders.Application.Dtos;
using Orders.Application.Policies.Commands.UpdatePolicy;

namespace Orders.API.Endpoints.Policies;

public record UpdatePolicyRequest(PolicyDto Policy);

public record UpdatePolicyResponse(bool IsSuccess);

public class UpdatePolicy : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/policies", async (UpdatePolicyRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdatePolicyCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdatePolicyResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdatePolicy")
        .Produces<UpdatePolicyResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Policy")
        .WithDescription("Update Policy")
        .RequireAuthorization();
    }
}