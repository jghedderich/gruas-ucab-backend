using Microsoft.Extensions.Logging;
using MediatR;
using Admin.Domain.Events;

namespace Admin.Application.Administrators.EventHandlers;

public class AdministratorUpdatedEventHandler(ILogger<AdministratorUpdatedEventHandler> logger)
    : INotificationHandler<AdministratorUpdatedEvent>
{
    public Task Handle(AdministratorUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
