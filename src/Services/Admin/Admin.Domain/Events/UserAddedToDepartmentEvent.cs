using Admin.Domain.Models;

namespace Admin.Domain.Events;

public record UserAddedToDepartmentEvent(Department Department, Guid UserId) : IDomainEvent;
