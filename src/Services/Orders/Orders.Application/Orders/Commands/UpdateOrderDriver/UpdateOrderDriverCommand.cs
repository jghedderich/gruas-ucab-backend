namespace Orders.Application.Orders.Commands.UpdateOrderDriver;

public record UpdateOrderDriverCommand(UpdateDriverDto Order) : ICommand<UpdateOrderDriverResult>;

public record UpdateOrderDriverResult(bool IsSuccess);

public class UpdateOrderDriverCommandValidator : AbstractValidator<UpdateOrderDriverCommand>
{
    public UpdateOrderDriverCommandValidator()
    {
        RuleFor(x => x.Order.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Order.DriverId).NotEmpty().WithMessage("Driver Id is required");
    }
}