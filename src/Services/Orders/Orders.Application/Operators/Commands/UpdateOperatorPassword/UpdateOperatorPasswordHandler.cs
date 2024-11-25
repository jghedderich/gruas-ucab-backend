using Orders.Application.Exceptions;

namespace Orders.Application.Operators.Commands.UpdateOperatorPassword;

public class UpdateOperatorPasswordHandlerI(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateOperatorPasswordCommand, UpdateOperatorPasswordResult>
{
    public async Task<UpdateOperatorPasswordResult> Handle(UpdateOperatorPasswordCommand command, CancellationToken cancellationToken)
    {
        var operatorId = command.Operator.Id;
        var operatorN = await dbContext.Operators
            .FindAsync([operatorId], cancellationToken: cancellationToken);

        if (operatorN == null)
        {
            throw new OperatorNotFoundException(command.Operator.Id);
        }

        if (operatorN.Password.Value != command.Operator.Password)
        {
            throw new WrongPasswordException(command.Operator.Id);
        }

        UpdateOperatorPassword(operatorN, command.Operator);

        dbContext.Operators.Update(operatorN);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateOperatorPasswordResult(true);
    }

    public static void UpdateOperatorPassword(Operator operatorN, UpdatePasswordDto dto)
    {
        operatorN.UpdatePassword(Password.Of(dto.NewPassword));
    }
}
