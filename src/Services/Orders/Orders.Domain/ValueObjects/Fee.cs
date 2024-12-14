namespace Orders.Domain.ValueObjects;

public record Fee
{
    public int BaseFee { get; } = default!;
    public int PerKm { get; } = default!;

    public Fee() { }
    private Fee(int baseF, int perKm)
    {
        BaseFee = baseF;
        PerKm = perKm;
    }

    public static Fee Of(int baseF, int perKm)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(baseF.ToString());
        ArgumentException.ThrowIfNullOrWhiteSpace(perKm.ToString());

        return new Fee(baseF, perKm);
    }
}
