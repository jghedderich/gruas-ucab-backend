using System;
using Admin.Domain.Events;
using Admin.Domain.ValueObjects;

namespace Admin.Domain.Models;

public class Department : Aggregate<Guid>
{
    public DepartmentName Name { get; private set; } = default!;
    public string Description { get; private set; } = default!; 
    public List<Guid> UserIds { get; private set; } = new(); // Lista de IDs de users asociados

    private Department() { }

    public static Department Create(
        Guid id,
        DepartmentName name,
        string description,
        List<Guid> userIds = null
    )
    {
        var department = new Department
        {
            Id = id,
            Name = name,
            Description = description,
            UserIds = userIds ?? new List<Guid>()
        };

        department.AddDomainEvent(new DepartmentCreatedEvent(department));

        return department;
    }

    public void Update(DepartmentName name, string description)
    {
        Name = name;
        Description = description;
        AddDomainEvent(new DepartmentUpdatedEvent(this));
    }

    public void AddUser(Guid userId)
{
    if (!UserIds.Contains(userId))
    {
        UserIds.Add(userId);
        AddDomainEvent(new UserAddedToDepartmentEvent(this, userId));
    }
}

public void RemoveUser(Guid userId)
{
    if (UserIds.Contains(userId))
    {
        UserIds.Remove(userId);
        AddDomainEvent(new UserRemovedFromDepartmentEvent(this, userId));
    }
}


    
}
