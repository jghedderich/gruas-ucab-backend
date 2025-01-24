
namespace Admin.Application.Administrators.Commands.CreateAdministrator;

public record CreateAdministratorCommand(AdministratorDto Administrator)
    : ICommand<CreateAdministratorResult>;

public record CreateAdministratorResult(Guid Id);

public class CreateAdministratorCommandValidator : AbstractValidator<CreateAdministratorCommand>
{
    public CreateAdministratorCommandValidator()
    {
        RuleFor(c => c.Administrator.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(c => c.Administrator.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(c => c.Administrator.Password).NotEmpty().WithMessage("Password is required");
    }
}
