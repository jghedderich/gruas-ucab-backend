

namespace Orders.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResult>;

public record CreateOrderResult(Guid Id);

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(o => o.Order.OperatorId).NotEmpty().WithMessage("Operator is required");
        RuleFor(o => o.Order.PolicyId).NotEmpty().WithMessage("Policy is required");
        RuleFor(o => o.Order.Client).NotEmpty().WithMessage("Client is required");
        RuleFor(o => o.Order.OrderStatus).NotEmpty().WithMessage("Status is required");
        RuleFor(o => o.Order.IncidentAddress).NotEmpty().WithMessage("Incident Address is required");
        RuleFor(o => o.Order.DestinationAddress).NotEmpty().WithMessage("Destination Address is required");
    }
}
