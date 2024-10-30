
namespace Providers.Application.Vehicles.EventHandlers;

public class VehicleCreatedEventHandler(ILogger<VehicleCreatedEventHandler> logger)
    : INotificationHandler<VehicleCreatedEvent>
{
    public Task Handle(VehicleCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}

