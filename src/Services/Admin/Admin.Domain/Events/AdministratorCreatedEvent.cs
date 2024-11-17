using Admin.Domain.Models;

namespace Admin.Domain.Events;

public record AdministratorCreatedEvent(Administrator Administrator) : IDomainEvent;
