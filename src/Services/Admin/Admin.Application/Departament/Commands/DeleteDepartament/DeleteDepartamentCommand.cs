using System;

namespace Admin.Application.Departments.Commands.DeleteDepartment;

public record DeleteDepartmentCommand(Guid DepartmentId)
    : ICommand<DeleteDepartmentResult>;

public record DeleteDepartmentResult(bool IsSuccess);

public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
{
    public DeleteDepartmentCommandValidator()
    {
        RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("El ID del Departament es requerido");
    }
}
