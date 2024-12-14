using Admin.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Admin.Application.Departments.EventHandlers;

public class DepartmentUpdatedEventHandler(ILogger<DepartmentUpdatedEventHandler> logger)
    : INotificationHandler<DepartmentUpdatedEvent>
{
    public Task Handle(DepartmentUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
