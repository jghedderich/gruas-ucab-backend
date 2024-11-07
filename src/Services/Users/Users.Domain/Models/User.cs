
using Users.Domain.Events;
using Users.Domain.ValueObjects;

namespace Users.Domain.Models; 
public class User : Aggregate<Guid>
{
    public Name Name { get; private set; } = default!;
    public Phone Phone { get; private set; } = default!;
    public Dni Dni { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Password Password { get; private set; } = default!;
    public Role Role { get; private set; } = default!;


    public static User Create(
            Guid id,
            Name name,
            Phone phone,
            Dni dni,
            Email email,
            Password password,
            Role role)
    {
        var user = new User
        {
            Id = id,
            Name = name,
            Phone = phone,
            Dni = dni,
            Email = email,
            Password = password,
            Role = role
        };

        user.AddDomainEvent(new UserCreatedEvent(user));

        return user;
    }

    public void Update(Name name, Phone phone, Email email, Password password, Role role)
    {
        Name = name;
        Phone = phone;
        Email = email;
        Password = password;
        Role = role;

        AddDomainEvent(new UserUpdatedEvent(this));
    }
}
}
