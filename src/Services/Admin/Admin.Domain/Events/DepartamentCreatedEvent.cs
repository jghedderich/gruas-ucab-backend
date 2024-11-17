using Admin.Domain.Models;


namespace Admin.Domain.Events;

public record DepartmentCreatedEvent(Department Department) : IDomainEvent;
