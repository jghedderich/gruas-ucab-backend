namespace Orders.Application.Policies.Commands.CreatePolicy;

public class CreatePolicyHandler(IApplicationDbContext dbContext) : ICommandHandler<CreatePolicyCommand, CreatePolicyResult>
{
    public async Task<CreatePolicyResult> Handle(CreatePolicyCommand command, CancellationToken cancellationToken)
    {
        var policy = CreateNewPolicy(command.Policy);

        dbContext.Policies.Add(policy);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreatePolicyResult(policy.Id);
    }

    private static Policy CreateNewPolicy(PolicyDto policyDto)
    {
        var newPolicy = Policy.Create(
                id: Guid.NewGuid(),
                name: policyDto.Name,
                ammountCovered: policyDto.AmountCovered,
                price: Price.Of(policyDto.Price.AnnualPrice,policyDto.Price.MonthlyPrice),
                fees: Fee.Of(policyDto.Fees.BaseFee,policyDto.Fees.PerKm)
            );

        return newPolicy;
    }
}
