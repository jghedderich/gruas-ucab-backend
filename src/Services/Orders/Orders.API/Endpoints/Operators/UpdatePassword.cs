using Orders.Application.Dtos;
using Orders.Application.Operators.Commands.UpdateOperatorPassword;

namespace Orders.API.Endpoints.Operators;

public record UpdateOperatorPasswordRequest(UpdatePasswordDto Operator);
public record UpdateOperatorPasswordResponse(bool IsSuccess);

public class UpdateOperatorPassword : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/operators/password", async (UpdateOperatorPasswordRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateOperatorPasswordCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateOperatorPasswordResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateOperatorPassword")
        .Produces<UpdateOperatorPasswordResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Operator Password")
        .WithDescription("Update Operator Password");
    }
}
