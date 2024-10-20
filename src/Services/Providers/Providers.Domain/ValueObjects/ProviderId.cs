namespace Providers.Domain.ValueObjects;

public record ProviderId
{
    public Guid Value { get; set; }
    private ProviderId(Guid value) {  Value = value; }
    public static ProviderId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("ProviderId cannot be empty.");
        }

        return new ProviderId(value);
    }
}
