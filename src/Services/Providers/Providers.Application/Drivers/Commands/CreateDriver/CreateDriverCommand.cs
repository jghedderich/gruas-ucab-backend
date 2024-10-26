
namespace Providers.Application.Drivers.Commands.CreateDriver;
public record CreateDriverCommand(DriverDto Driver)
    : ICommand<CreateDriverResult>;
public record CreateDriverResult(Guid Id);

public class CreateDriverCommandValidator : AbstractValidator<CreateDriverCommand>
{
    public CreateDriverCommandValidator()
    {
        RuleFor(p => p.Driver.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(p => p.Driver.Dni).NotEmpty().WithMessage("Dni is required");
        RuleFor(p => p.Driver.Phone).NotEmpty().WithMessage("Phone is required");
        RuleFor(p => p.Driver.Email).NotEmpty().WithMessage("Email is required");
    }
}

