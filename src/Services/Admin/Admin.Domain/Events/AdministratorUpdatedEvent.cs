using Admin.Domain.Models;

namespace Admin.Domain.Events;

public record AdministratorUpdatedEvent(Administrator Administrator) : IDomainEvent;
