using System;
using Admin.Application.Dtos;

namespace Admin.Application.Administrators.Commands.DeleteAdministrator;

public record DeleteAdministratorCommand(Guid AdministratorId)
    : ICommand<DeleteAdministratorResult>;

public record DeleteAdministratorResult(bool IsSuccess);

public class DeleteAdministratorCommandValidator : AbstractValidator<DeleteAdministratorCommand>
{
    public DeleteAdministratorCommandValidator()
    {
        RuleFor(x => x.AdministratorId).NotEmpty().WithMessage("El Administrador es requerido");
    }
}
