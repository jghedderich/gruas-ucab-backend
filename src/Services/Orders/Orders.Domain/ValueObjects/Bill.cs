namespace Orders.Domain.ValueObjects;

public record Bill
{
    public decimal BaseFee { get; } = default!;
    public decimal CostPerKm { get; } = default!;
    public decimal Subtotal { get; set; } = default!;
    public decimal Coverage { get; } = default!;
    public decimal Total { get; } = default!;

    private Bill(decimal baseFee, decimal costPerKm, decimal coverage)
    {
        BaseFee = baseFee;
        CostPerKm = costPerKm;
        Coverage = coverage;
        Subtotal = baseFee + costPerKm;
        Total = Subtotal - Coverage;
    }

    public static Bill Of(decimal baseFee, decimal costPerKm, decimal coverage)
    {
        if (baseFee < 0) throw new ArgumentOutOfRangeException(nameof(baseFee), "Base fee cannot be negative.");
        if (costPerKm < 0) throw new ArgumentOutOfRangeException(nameof(costPerKm), "Cost per km cannot be negative.");
        if (coverage < 0) throw new ArgumentOutOfRangeException(nameof(coverage), "Coverage cannot be negative.");

        return new Bill(baseFee, costPerKm, coverage);
    }
}

