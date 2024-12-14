using Microsoft.Extensions.Logging;
using MediatR;

namespace Admin.Application.Rates.EventHandlers;

public class RateCreatedEventHandler(ILogger<RateCreatedEventHandler> logger)
    : INotificationHandler<RateCreatedEvent>
{
    public Task Handle(RateCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
