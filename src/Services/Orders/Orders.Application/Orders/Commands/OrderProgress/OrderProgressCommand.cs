namespace Orders.Application.Orders.Commands.OrderProgress;

public record OrderProgressCommand(OrderProgressDto Order)
    : ICommand<OrderProgressResult>;

public record OrderProgressResult(bool IsSuccess, string Status);

public class OrderProgressCommandValidator : AbstractValidator<OrderProgressCommand>
{
    public OrderProgressCommandValidator()
    {
        RuleFor(x => x.Order.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Order.OrderStatus).NotEmpty().WithMessage("Status is required");
        RuleFor(x => x.Order.Latitude).NotEmpty().WithMessage("Latitude is required");
        RuleFor(x => x.Order.Longitude).NotEmpty().WithMessage("Longitude is required");
        RuleFor(x => x.Order.Zip).NotEmpty().WithMessage("Zip is required");
        RuleFor(x => x.Order.City).NotEmpty().WithMessage("City is required");
        RuleFor(x => x.Order.State).NotEmpty().WithMessage("State is required");
        RuleFor(x => x.Order.AddressLine1).NotEmpty().WithMessage("AddressLine1 is required");
        RuleFor(x => x.Order.AddressLine2).NotEmpty().WithMessage("AddressLine2 is required");
    }
}

