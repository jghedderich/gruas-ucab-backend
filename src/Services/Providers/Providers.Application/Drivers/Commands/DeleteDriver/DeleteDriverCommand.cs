namespace Providers.Application.Drivers.Commands.DeleteDriver;

public record DeleteDriverCommand(Guid DriverId) : ICommand<DeleteDriverResult>;

public record DeleteDriverResult(bool IsSuccess);

public class DeleteDriverCommandValidator : AbstractValidator<DeleteDriverCommand>
{
    public DeleteDriverCommandValidator()
    {
        RuleFor(x => x.DriverId).NotEmpty().WithMessage("DriverId is required");
    }
}
