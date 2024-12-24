using Admin.Application.Exceptions;
using BuildingBlocks.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Application.Administrators.Commands.UpdateAdministratorPassword;

public class UpdateAdministratorPasswordHandlerI(IApplicationDbContext dbContext, IPasswordHasher passwordHasher)
    : ICommandHandler<UpdateAdministratorPasswordCommand, UpdateAdministratorPasswordResult>
{
    public async Task<UpdateAdministratorPasswordResult> Handle(UpdateAdministratorPasswordCommand command, CancellationToken cancellationToken)
    {
        var administratorId = command.Administrator.Id;
        var administrator = await dbContext.Administrators
            .FindAsync(new object[] { administratorId }, cancellationToken: cancellationToken);

        if (administrator == null)
        {
            throw new AdministratorNotFoundException(command.Administrator.Id);
        }

        UpdateAdministratorPassword(administrator, command.Administrator);

        dbContext.Administrators.Update(administrator);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateAdministratorPasswordResult(true);
    }

    public void UpdateAdministratorPassword(Administrator administrator, UpdatePasswordDto dto)
    {
        administrator.UpdatePassword(Password.Create(passwordHasher.Hash(dto.NewPassword)));
    }
}
