
namespace Providers.Application.Providers.Commands.UpdateProviderPassword;

public class UpdateProviderPasswordHandlerI(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateProviderPasswordCommand, UpdateProviderPasswordResult>
{
    public async Task<UpdateProviderPasswordResult> Handle(UpdateProviderPasswordCommand command, CancellationToken cancellationToken)
    {
        var providerId = command.Provider.Id;
        var provider = await dbContext.Providers
            .FindAsync([providerId], cancellationToken: cancellationToken) 
            ?? throw new ProviderNotFoundException(command.Provider.Id);
        
        UpdateProviderPassword(provider, command.Provider);

        dbContext.Providers.Update(provider);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateProviderPasswordResult(true);
    }

    public static void UpdateProviderPassword(Provider provider, UpdatePasswordDto dto)
    {
        provider.UpdatePassword(password: Password.Of(dto.NewPassword));
    }
}
