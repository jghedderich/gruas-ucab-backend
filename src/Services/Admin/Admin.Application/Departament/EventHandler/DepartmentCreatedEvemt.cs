using Microsoft.Extensions.Logging;
using MediatR;

namespace Admin.Application.Departments.EventHandlers;

public class DepartmentCreatedEventHandler(ILogger<DepartmentCreatedEventHandler> logger)
    : INotificationHandler<DepartmentCreatedEvent>
{
    public Task Handle(DepartmentCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
