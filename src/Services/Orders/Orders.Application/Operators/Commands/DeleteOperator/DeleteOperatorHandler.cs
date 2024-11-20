
using Orders.Application.Exceptions;

namespace Orders.Application.Operators.Commands.DeleteOperator;

public class DeleteOperatorHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteOperatorCommand, DeleteOperatorResult>
{
    public async Task<DeleteOperatorResult> Handle(DeleteOperatorCommand command, CancellationToken cancellationToken)
    {
        var operatorN = await dbContext.Operators
            .FindAsync([command.OperatorId], cancellationToken)
            ?? throw new OperatorNotFoundException(command.OperatorId);

        dbContext.Operators.Remove(operatorN);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteOperatorResult(true);
    }
}
