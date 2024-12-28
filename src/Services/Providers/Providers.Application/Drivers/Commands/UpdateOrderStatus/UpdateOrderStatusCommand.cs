
namespace Providers.Application.Drivers.Commands.UpdateOrderStatus;

public record UpdateOrderStatusCommand(UpdateOrderStatusDto Order)
    : ICommand<UpdateOrderStatusResult>;

public record UpdateOrderStatusResult(Guid Id, bool IsSuccess);
public class UpdateOrderStatusCommandValidator : AbstractValidator<UpdateOrderStatusCommand>
{
    public UpdateOrderStatusCommandValidator()
    {
        RuleFor(x => x.Order.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Order.Status).NotEmpty().WithMessage("Status is required");
    }
}
