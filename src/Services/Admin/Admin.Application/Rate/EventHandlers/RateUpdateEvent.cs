using Admin.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Admin.Application.Rates.EventHandlers;

public class RateUpdatedEventHandler(ILogger<RateUpdatedEventHandler> logger)
    : INotificationHandler<RateUpdatedEvent>
{
    public Task Handle(RateUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}

