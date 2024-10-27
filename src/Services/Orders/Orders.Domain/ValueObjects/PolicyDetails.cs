
namespace Orders.Domain.ValueObjects;

public record PolicyDetails
{
    public string PolicyNumber { get; } = default!;
    public string InsuranceCompany { get; } = default!;

    private PolicyDetails(string policyNumber, string insuranceCompany) 
    { 
        PolicyNumber = policyNumber;
        InsuranceCompany = insuranceCompany;
    }

    public static PolicyDetails Of(string policyNumber, string insuranceCompany)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(policyNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(insuranceCompany);

        return new PolicyDetails(policyNumber, insuranceCompany);
    }
}
