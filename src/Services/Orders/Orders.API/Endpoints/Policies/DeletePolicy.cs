using Orders.Application.Policies.Commands.DeletePolicy;

namespace Orders.API.Endpoints.Policies;

public record DeletePolicyResponse(bool IsSuccess);

public class DeletePolicy : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/policies/{id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeletePolicyCommand(Id));

            var response = result.Adapt<DeletePolicyResponse>();

            return Results.Ok(response);
        })
        .WithName("DeletePolicy")
        .Produces<DeletePolicyResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Policy")
        .WithDescription("Delete Policy")
        .RequireAuthorization();
    }
}
