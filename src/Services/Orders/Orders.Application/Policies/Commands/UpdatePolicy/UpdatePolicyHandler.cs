using Orders.Application.Exceptions;

namespace Orders.Application.Policies.Commands.UpdatePolicy;

public class UpdatePolicyHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdatePolicyCommand, UpdatePolicyResult>
{
    public async Task<UpdatePolicyResult> Handle(UpdatePolicyCommand command, CancellationToken cancellationToken)
    {
        var policyId = command.Policy.Id;
        var policy = await dbContext.Policies
            .FindAsync([policyId], cancellationToken: cancellationToken) ?? throw new PolicyNotFoundException(command.Policy.Id);

        UpdatePolicyWithNewValues(policy, command.Policy);

        dbContext.Policies.Update(policy);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdatePolicyResult(true);
    }

    public static void UpdatePolicyWithNewValues(Policy policy, PolicyDto policyDto)
    {
        var updatedName = policyDto.Name;
        var updatedAmountCovered = policyDto.AmountCovered;
        var updatedPriceAnnual = policyDto.Price.AnnualPrice;
        var updatedPriceMonthly = policyDto.Price.MonthlyPrice;
        var updatedFeeBase = policyDto.Fees.BaseFee;
        var updatedFeesPerKm = policyDto.Fees.PerKm;

        policy.Update(updatedName,updatedAmountCovered,Price.Of(updatedPriceAnnual,updatedPriceMonthly), Fee.Of(updatedFeeBase,updatedFeesPerKm));
    }
}