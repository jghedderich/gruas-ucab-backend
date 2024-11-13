using Admin.Domain.Models;

namespace Admin.Domain.Events;

public record UserRemovedFromDepartmentEvent(Department Department, Guid UserId) : IDomainEvent;
