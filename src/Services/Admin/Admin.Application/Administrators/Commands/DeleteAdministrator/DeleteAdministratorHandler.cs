using System.Diagnostics.CodeAnalysis;

namespace Admin.Application.Administrators.Commands.DeleteAdministrator;

[ExcludeFromCodeCoverage]
public class DeleteAdministratorHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteAdministratorCommand, DeleteAdministratorResult>
{
    public async Task<DeleteAdministratorResult> Handle(DeleteAdministratorCommand command, CancellationToken cancellationToken)
    {
        var administrator = await dbContext.Administrators
            .FindAsync(command.AdministratorId, cancellationToken)
            ?? throw new AdministratorNotFoundException(command.AdministratorId);

        dbContext.Administrators.Remove(administrator);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteAdministratorResult(true);
    }
}
