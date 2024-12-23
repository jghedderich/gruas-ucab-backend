using BuildingBlocks.Hashing;

namespace Admin.Application.Administrators.Commands.UpdateAdministrator;

public class UpdateAdministratorHandler(IApplicationDbContext dbContext, IPasswordHasher passwordHasher)
    : ICommandHandler<UpdateAdministratorCommand, UpdateAdministratorResult>
{
    public async Task<UpdateAdministratorResult> Handle(UpdateAdministratorCommand command, CancellationToken cancellationToken)
    {
        var administratorId = command.Administrator.Id;
        var administrator = await dbContext.Administrators
            .FindAsync(new object[] { administratorId }, cancellationToken: cancellationToken);

        if (administrator == null)
        {
            throw new AdministratorNotFoundException(command.Administrator.Id);
        }

        UpdateAdministratorWithNewValues(administrator, command.Administrator);

        dbContext.Administrators.Update(administrator);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateAdministratorResult(true);
    }

    public void UpdateAdministratorWithNewValues(Administrator administrator, AdministratorDto administratorDto)
    {
        administrator.Update(
            name: administratorDto.Name,
            email: Email.Create(administratorDto.Email),
            password: Password.Create(passwordHasher.Hash(administratorDto.Password)));
    }
  
       
}
