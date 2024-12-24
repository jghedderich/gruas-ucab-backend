using BuildingBlocks.Hashing;

namespace Admin.Application.Administrators.Commands.CreateAdministrator;

public class CreateAdministratorHandler(IApplicationDbContext dbContext, IPasswordHasher passwordHasher)
    : ICommandHandler<CreateAdministratorCommand, CreateAdministratorResult>
{
    public async Task<CreateAdministratorResult> Handle(CreateAdministratorCommand command, CancellationToken cancellationToken)
    {
        var administrator = CreateNewAdministrator(command.Administrator);

        dbContext.Administrators.Add(administrator);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateAdministratorResult(administrator.Id);
    }

    private Administrator CreateNewAdministrator(AdministratorDto administratorDto)
    {
        var newAdministrator = Administrator.Create(
            id: Guid.NewGuid(),
            name: AdministratorName.Of(administratorDto.Name.FirstName, administratorDto.Name.LastName),
            email: Email.Create(administratorDto.Email),
            password: Password.Create(passwordHasher.Hash(administratorDto.Password)) 
        );

        return newAdministrator;
    }
}
