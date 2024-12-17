using Microsoft.Extensions.Logging;
using MediatR;

namespace Admin.Application.Administrators.EventHandlers;

public class AdministratorCreatedEventHandler(ILogger<AdministratorCreatedEventHandler> logger)
    : INotificationHandler<AdministratorCreatedEvent>
{
    public Task Handle(AdministratorCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
