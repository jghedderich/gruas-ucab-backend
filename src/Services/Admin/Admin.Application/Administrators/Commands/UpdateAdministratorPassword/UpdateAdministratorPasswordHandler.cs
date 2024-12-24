using BuildingBlocks.Hashing;

namespace Admin.Application.Administrators.Commands.UpdateAdministratorPassword;

public class UpdateAdministratorPasswordHandlerI(IApplicationDbContext dbContext, IPasswordHasher passwordHasher)
    : ICommandHandler<UpdateAdministratorPasswordCommand, UpdateAdministratorPasswordResult>
{
    public async Task<UpdateAdministratorPasswordResult> Handle(UpdateAdministratorPasswordCommand command, CancellationToken cancellationToken)
    {
        var providerId = command.Administrator.Id;
        var provider = await dbContext.Administrators
            .FindAsync([providerId], cancellationToken: cancellationToken) 
            ?? throw new AdministratorNotFoundException(command.Administrator.Id);

        if (administrator == null)
        {
            throw new AdministratorNotFoundException(command.Administrator.Id);
        }

        UpdateAdministratorPassword(provider, command.Administrator);

        dbContext.Administrators.Update(provider);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateAdministratorPasswordResult(true);
    }

    public void UpdateAdministratorPassword(Administrator provider, UpdatePasswordDto dto)
    {
        provider.UpdatePassword(password: Password.Create(passwordHasher.Hash(dto.NewPassword)));
    }
}
