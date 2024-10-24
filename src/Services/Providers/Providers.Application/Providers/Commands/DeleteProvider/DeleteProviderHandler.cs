namespace Providers.Application.Providers.Commands.DeleteProvider;

public class DeleteProviderHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteProviderCommand, DeleteProviderResult>
{
    public async Task<DeleteProviderResult> Handle(DeleteProviderCommand command, CancellationToken cancellationToken)
    {
        var provider = await dbContext.Providers
            .FindAsync([command.ProviderId], cancellationToken)
            ?? throw new ProviderNotFoundException(command.ProviderId);

        dbContext.Providers.Remove(provider);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteProviderResult(true);
    }
}
