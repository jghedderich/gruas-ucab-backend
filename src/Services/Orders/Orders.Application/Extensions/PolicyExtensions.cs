namespace Orders.Application.Extensions;

public static class PolicyExtensions
{
    public static IEnumerable<PolicyDto> ToPolicyDtoList(this IEnumerable<Policy> policies)
    {
        return policies.Select( p => new PolicyDto(
                Id: p.Id,
                Name: p.Name,
                AmountCovered: p.AmountCovered,
                Price: new PriceDto(p.Price.AnnualPrice,p.Price.MonthlyPrice),
                Fees: new FeeDto(p.Fees.BaseFee,p.Fees.PerKm)
            ));
    }

    public static PolicyDto ToPolicyDto(this Policy policy)
    {
        return DtoFromPolicy(policy);
    }

    private static PolicyDto DtoFromPolicy(Policy policy) 
    {
        return new PolicyDto(
                Id: policy.Id,
                Name: policy.Name,
                AmountCovered: policy.AmountCovered,
                Price: new PriceDto(policy.Price.AnnualPrice,policy.Price.MonthlyPrice),
                Fees: new FeeDto(policy.Fees.BaseFee,policy.Fees.PerKm)
            );
    }
}