using Admin.Application.Dtos;
using Admin.Application.Exceptions;

namespace Admin.Application.Departments.Commands.DeleteDepartment;

public class DeleteDepartmentHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteDepartmentCommand, DeleteDepartmentResult>
{
    public async Task<DeleteDepartmentResult> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
    {
        var department = await dbContext.Departments
            .FindAsync(command.DepartmentId, cancellationToken)
            ?? throw new DepartmentNotFoundException(command.DepartmentId);

        dbContext.Departments.Remove(department);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteDepartmentResult(true);
    }
}
