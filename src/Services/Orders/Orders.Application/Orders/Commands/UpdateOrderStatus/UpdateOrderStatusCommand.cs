namespace Orders.Application.Orders.Commands.UpdateOrderStatus;

public record UpdateOrderStatusCommand(UpdateStatusDto Order)
    : ICommand<UpdateOrderStatusResult>;

public record UpdateOrderStatusResult(bool IsSuccess);

public class UpdateOrderStatusCommandValidator : AbstractValidator<UpdateOrderStatusCommand>
{
    public UpdateOrderStatusCommandValidator()
    {
        RuleFor(x => x.Order.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Order.OrderStatus).NotEmpty().WithMessage("Status is required");
    }
}
