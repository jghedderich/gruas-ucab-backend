using Orders.Application.Exceptions;

namespace Orders.Application.Operators.Commands.UpdateOperator;
public class UpdateOperatorHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateOperatorCommand, UpdateOperatorResult>
{
    public async Task<UpdateOperatorResult> Handle(UpdateOperatorCommand command, CancellationToken cancellationToken)
    {
        var operatorId = command.Operator.Id;
        var operatorN = await dbContext.Operators
            .FindAsync([operatorId], cancellationToken: cancellationToken);

        if (operatorN == null)
        {
            throw new OperatorNotFoundException(command.Operator.Id);
        }

        UpdateOperatorWithNewValues(operatorN, command.Operator);

        dbContext.Operators.Update(operatorN);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateOperatorResult(true);
    }

    public static void UpdateOperatorWithNewValues(Operator operatorN, OperatorDto operatorDto)
    {
        var updatedName = operatorDto.Name;
        var updatedEmail = operatorDto.Email;
        var updatedPassword = operatorDto.Password;
        var updatedDniType = operatorDto.Dni.ToDniType();
        var updatedNumber = operatorDto.Dni.Number;
        var updatedPhone = operatorDto.Phone;

        operatorN.Update(
            operatorName: Name.Of(updatedName.FirstName, updatedName.LastName),
            email: Email.Of(updatedEmail),
            password: Password.Of(updatedPassword),
            dni: Dni.Of(updatedDniType, updatedNumber),
            phone: Phone.Of(updatedPhone)
            );
    }
}