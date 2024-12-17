using Admin.Application.Dtos;
using BuildingBlocks.CQRS;
using System.Threading.Tasks;
using System.Threading;

namespace Admin.Application.Administrators.Commands.CreateAdministrator;

public class CreateAdministratorHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateAdministratorCommand, CreateAdministratorResult>
{
    public async Task<CreateAdministratorResult> Handle(CreateAdministratorCommand command, CancellationToken cancellationToken)
    {
        var administrator = CreateNewAdministrator(command.Administrator);

        dbContext.Administrators.Add(administrator);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateAdministratorResult(administrator.Id);
    }

    private static Administrator CreateNewAdministrator(AdministratorDto administratorDto)
    {
        var newAdministrator = Administrator.Create(
            id: Guid.NewGuid(),
            name: administratorDto.Name, 
            email: Email.Create(administratorDto.Email),
            password: Password.Create(administratorDto.Password) 
        );

        return newAdministrator;
    }
}
