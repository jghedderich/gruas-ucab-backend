using Orders.Application.Exceptions;

namespace Orders.Application.Policies.Commands.DeletePolicy;

public class DeletePolicyHandler(IApplicationDbContext dbContext) : ICommandHandler<DeletePolicyCommand, DeletePolicyResult>
{
    public async Task<DeletePolicyResult> Handle(DeletePolicyCommand command, CancellationToken cancellationToken)
    {
        var policy = await dbContext.Policies
            .FindAsync([command.PolicyId], cancellationToken)
            ?? throw new PolicyNotFoundException(command.PolicyId);

        dbContext.Policies.Remove(policy);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeletePolicyResult(true);
    }
}