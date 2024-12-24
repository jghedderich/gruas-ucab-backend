namespace Admin.Domain.Models;

public class Administrator: Aggregate<Guid>
{
    public AdministratorName Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Password Password { get; private set; } = default!;

    private Administrator() { }

    public static Administrator Create(
        Guid id,
        AdministratorName name,
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
        AdministratorName name, 
        Email email)
    {
        Name = name;
        Email = email;

        AddDomainEvent(new AdministratorUpdatedEvent(this));
    }

    public void UpdatePassword(Password password)
    {
        Password = password;
    }
}

