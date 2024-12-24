using Admin.Application.Dtos;

namespace Admin.Application.Administrators.Commands.UpdateAdministrator;

public record UpdateAdministratorCommand(AdministratorDto Administrator)
    : ICommand<UpdateAdministratorResult>;

public record UpdateAdministratorResult(bool IsSuccess);

public class UpdateAdministratorCommandValidator : AbstractValidator<UpdateAdministratorCommand>
{
    public UpdateAdministratorCommandValidator()
    {
        RuleFor(x => x.Administrator.Id).NotEmpty().WithMessage("Id es requerido");
        RuleFor(x => x.Administrator.Name).NotEmpty().WithMessage("Name es requerido");
        RuleFor(x => x.Administrator.Email).NotEmpty().WithMessage("Email es requerido");
    }
}
