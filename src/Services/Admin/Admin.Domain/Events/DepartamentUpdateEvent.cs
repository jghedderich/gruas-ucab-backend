using Admin.Domain.Models;

namespace Admin.Domain.Events;

public record DepartmentUpdatedEvent(Department Department) : IDomainEvent;

