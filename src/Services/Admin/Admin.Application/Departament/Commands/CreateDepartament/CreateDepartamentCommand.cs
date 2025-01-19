
namespace Admin.Application.Departament.Commands.CreateDepartament;

public record CreateDepartmentCommand(DepartmentDto Department)
    : ICommand<CreateDepartmentResult>;

public record CreateDepartmentResult(Guid Id);

public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(c => c.Department.DepartmentName).NotEmpty().WithMessage("Name is required");
    }
}
