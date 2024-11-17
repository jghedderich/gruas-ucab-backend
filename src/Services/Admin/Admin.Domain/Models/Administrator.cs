using Admin.Domain.Events;
using Admin.Domain.ValueObjects;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace Admin.Domain.Models;

public class Administrator: Aggregate<Guid>
{
    public string Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Password Password { get; private set; } = default!;

    private Administrator() { }

    public static Administrator Create(
        Guid id,
        string name,
        Email email,
        Password password)
    {
        var admin = new Administrator
        {
            Id = id,
            Name = name,
            Email = email,
            Password = password,
        };

        admin.AddDomainEvent(new AdministratorCreatedEvent(admin));
        return admin;
    }
    public void Update(
        string name, 
        Email email, 
        Password password)
    {
        Name = name;
        Email = email;
        Password = password;

        AddDomainEvent(new AdministratorUpdatedEvent(this));
    }
}

