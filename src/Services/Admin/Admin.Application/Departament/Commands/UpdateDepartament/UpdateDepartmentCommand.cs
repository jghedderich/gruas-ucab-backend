using Admin.Application.Dtos;

namespace Admin.Application.Departments.Commands.UpdateDepartment;

public record UpdateDepartmentCommand(DepartmentDto Department)
    : ICommand<UpdateDepartmentResult>;

public record UpdateDepartmentResult(bool IsSuccess);

public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(x => x.Department.Id).NotEmpty().WithMessage("Id es requerido");
        RuleFor(x => x.Department.DepartmentName).NotEmpty().WithMessage("Department name es requerido");
    }
}
