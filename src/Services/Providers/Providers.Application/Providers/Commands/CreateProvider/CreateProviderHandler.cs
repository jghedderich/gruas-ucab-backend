using BuildingBlocks.Hashing;
using Providers.Application.Dtos;

namespace Providers.Application.Providers.Commands.CreateProvider;

public class CreateProviderHandler(IApplicationDbContext dbContext, IPasswordHasher passwordHasher)
    : ICommandHandler<CreateProviderCommand, CreateProviderResult>
{
    public async Task<CreateProviderResult> Handle(CreateProviderCommand command, CancellationToken cancellationToken)
    {
        var provider = CreateNewProvider(command.Provider);
        
        dbContext.Providers.Add(provider);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateProviderResult(provider.Id);
    }

    private Provider CreateNewProvider(ProviderDto providerDto)
    {
        var company = Company.Of(
            providerDto.Company.Name, 
            providerDto.Company.Description, 
            providerDto.Company.Rif, 
            providerDto.Company.City, 
            providerDto.Company.State);

        var dniType = providerDto.Dni.ToDniType();

        var dni = Dni.Of(dniType, providerDto.Dni.Number);

        var newProvider = Provider.Create(
            id: Guid.NewGuid(),
            providerName: ProviderName.Of(providerDto.Name.FirstName, providerDto.Name.LastName),
            email: Email.Of(providerDto.Email!),
            password: Password.Of(passwordHasher.Hash(providerDto.Password!)),
            phone: Phone.Of(providerDto.Phone),
            company: company,
            dni: dni
            );

        return newProvider;
    }
}
