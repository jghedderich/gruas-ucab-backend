
using System.Diagnostics.CodeAnalysis;

namespace Providers.Application.Providers.Commands.UpdateProvider;

[ExcludeFromCodeCoverage]
public class UpdateProviderHandlerI(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateProviderCommand, UpdateProviderResult>
{
    public async Task<UpdateProviderResult> Handle(UpdateProviderCommand command, CancellationToken cancellationToken)
    {
        var providerId = command.Provider.Id;
        var provider = await dbContext.Providers
            .FindAsync([providerId], cancellationToken: cancellationToken) 
            ?? throw new ProviderNotFoundException(command.Provider.Id);
        
        UpdateProviderWithNewValues(provider, command.Provider);

        dbContext.Providers.Update(provider);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateProviderResult(true);
    }

    public static void UpdateProviderWithNewValues(Provider provider, ProviderDto providerDto)
    {
        var updatedName = providerDto.Name;
        
        var company = Company.Of(
            providerDto.Company.Name, 
            providerDto.Company.Description, 
            providerDto.Company.Rif, 
            providerDto.Company.City, 
            providerDto.Company.State);

        provider.Update(
            providerName: ProviderName.Of(updatedName.FirstName, updatedName.LastName), 
            company: company);
    }
}
