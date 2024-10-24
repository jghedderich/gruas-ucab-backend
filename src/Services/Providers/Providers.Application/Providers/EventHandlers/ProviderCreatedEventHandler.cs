
namespace Providers.Application.Providers.EventHandlers;

public class ProviderCreatedEventHandler(ILogger<ProviderCreatedEventHandler> logger)
    : INotificationHandler<ProviderCreatedEvent>
{
    public Task Handle(ProviderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name); 
        throw new NotImplementedException();
    }
}
