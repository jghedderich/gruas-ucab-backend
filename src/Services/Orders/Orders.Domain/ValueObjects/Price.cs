namespace Orders.Domain.ValueObjects;

public record Price
{
    public int AnnualPrice { get; } = default!;
    public int MonthlyPrice { get; } = default!;

    private Price(int annualPrice, int monthlyPrice)
    {
        AnnualPrice = annualPrice;
        MonthlyPrice = monthlyPrice;
    }

    public static Price Of( int annualPrice, int monthlyPrice)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(annualPrice.ToString());
        ArgumentException.ThrowIfNullOrWhiteSpace(monthlyPrice.ToString());

        return new Price(annualPrice, monthlyPrice);
    }
}
