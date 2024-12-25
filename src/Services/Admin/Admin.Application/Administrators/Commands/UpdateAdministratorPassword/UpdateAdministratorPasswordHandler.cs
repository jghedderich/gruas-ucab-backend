using BuildingBlocks.Hashing;

namespace Admin.Application.Administrators.Commands.UpdateAdministratorPassword;

public class UpdateAdministratorPasswordHandlerI(IApplicationDbContext dbContext, IPasswordHasher passwordHasher)
    : ICommandHandler<UpdateAdministratorPasswordCommand, UpdateAdministratorPasswordResult>
{
    public async Task<UpdateAdministratorPasswordResult> Handle(UpdateAdministratorPasswordCommand command, CancellationToken cancellationToken)
    {
        var adminId = command.Administrator.Id;
        var admin = await dbContext.Administrators
            .FindAsync([adminId], cancellationToken: cancellationToken) 
            ?? throw new AdministratorNotFoundException(command.Administrator.Id);

        if (admin == null)
        {
            throw new AdministratorNotFoundException(command.Administrator.Id);
        }

        UpdateAdministratorPassword(admin, command.Administrator);

        dbContext.Administrators.Update(admin);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateAdministratorPasswordResult(true);
    }

    public void UpdateAdministratorPassword(Administrator provider, UpdatePasswordDto dto)
    {
        provider.UpdatePassword(password: Password.Create(passwordHasher.Hash(dto.NewPassword)));
    }
}
