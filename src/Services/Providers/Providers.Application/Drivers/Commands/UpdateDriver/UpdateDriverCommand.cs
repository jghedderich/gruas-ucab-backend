namespace Providers.Application.Drivers.Commands.UpdateDriver;

public record UpdateDriverCommand(DriverDto Driver) : ICommand<UpdateDriverResult>;

public record UpdateDriverResult(bool IsSuccess);

public class UpdateDriverCommandValidator : AbstractValidator<UpdateDriverCommand>
{
    public UpdateDriverCommandValidator()
    {
        RuleFor(x => x.Driver.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Driver.Name.FirstName).NotEmpty().WithMessage("First name is required");
        RuleFor(x => x.Driver.Name.LastName).NotEmpty().WithMessage("Last name is required");
        RuleFor(x => x.Driver.Phone).NotEmpty().WithMessage("Phone is required");
        RuleFor(x => x.Driver.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.Driver.Dni.Number).NotEmpty().WithMessage("Dni number is required");
    }
}