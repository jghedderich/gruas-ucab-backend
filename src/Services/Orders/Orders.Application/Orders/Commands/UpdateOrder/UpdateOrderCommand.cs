
namespace Orders.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(OrderDto Order) : ICommand<UpdateOrderResult>;

public record UpdateOrderResult(bool IsSuccess);

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Order.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(o => o.Order.Client).NotEmpty().WithMessage("Client is required");
        RuleFor(o => o.Order.IncidentAddress).NotEmpty().WithMessage("Incident Address is required");
        RuleFor(o => o.Order.DestinationAddress).NotEmpty().WithMessage("Destination Address is required");
    }
}