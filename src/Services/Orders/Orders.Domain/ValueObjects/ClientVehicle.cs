namespace Orders.Domain.ValueObjects;

public record ClientVehicle
{
    public string Brand { get; } = default!;
    public string Model { get; } = default!;
    public int Year { get; } = default!;
    public VehicleType TypeV { get; } = default!;


    public ClientVehicle() { }
    private ClientVehicle(string brand, string model, int year, VehicleType typev)
    {
        Brand = brand;
        Model = model;
        Year = year;
        TypeV = typev;
    }

    public static ClientVehicle Of(string brand, string model, int year, VehicleType typeV)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(brand);
        ArgumentException.ThrowIfNullOrWhiteSpace(model);
        ArgumentException.ThrowIfNullOrWhiteSpace(year.ToString());
        ArgumentException.ThrowIfNullOrWhiteSpace(typeV.ToString());

        return new ClientVehicle(brand, model, year, typeV);
    }

}

public enum VehicleType
{
    Suv,
    Sedan,
    Pickup,
    Motorcycle,
    Van,
    HatchBack,
    Coupe
}
