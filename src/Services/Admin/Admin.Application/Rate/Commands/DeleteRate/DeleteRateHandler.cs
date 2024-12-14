using Admin.Application.Dtos;
using Admin.Application.Exceptions;

namespace Admin.Application.Rates.Commands.DeleteRate;

public class DeleteRateHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteRateCommand, DeleteRateResult>
{
    public async Task<DeleteRateResult> Handle(DeleteRateCommand command, CancellationToken cancellationToken)
    {
        var rate = await dbContext.Rates
            .FindAsync(command.RateId, cancellationToken)
            ?? throw new RateNotFoundException(command.RateId);

        dbContext.Rates.Remove(rate);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteRateResult(true);
    }
}

