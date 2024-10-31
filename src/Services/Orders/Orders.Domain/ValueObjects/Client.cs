namespace Orders.Domain.ValueObjects;

public record Client // CLIENTE
{
    public Name Name { get; } = default!;
    public Dni Dni { get; } = default!;
    public Phone Phone { get; } = default!;
    public Email Email { get; } = default!;

    public ClientVehicle ClientVehicle { get; } = default!;

    private Client(Name name, Dni dni, Phone phone, Email email, ClientVehicle clientVehicle)
    {
        Name = name;
        Dni = dni;
        Phone = phone;
        Email = email;
        ClientVehicle = clientVehicle;
    }

    public static Client Of(Name name, Dni dni, Phone phone, Email email, ClientVehicle clientVehicle)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name.ToString());
        ArgumentException.ThrowIfNullOrWhiteSpace(dni.ToString());
        ArgumentException.ThrowIfNullOrWhiteSpace(phone.ToString());
        ArgumentException.ThrowIfNullOrWhiteSpace(email.ToString());
        ArgumentException.ThrowIfNullOrWhiteSpace(clientVehicle.ToString());

        return new Client(name, dni, phone, email, clientVehicle);
    }
}
