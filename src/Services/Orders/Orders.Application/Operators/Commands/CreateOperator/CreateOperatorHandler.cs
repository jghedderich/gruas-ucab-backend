
namespace Orders.Application.Operators.Commands.CreateOperator;

public class CreateOperatorHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateOperatorCommand, CreateOperatorResult>
{
    public async Task<CreateOperatorResult> Handle(CreateOperatorCommand command, CancellationToken cancellationToken)
    {
        var operatorN = CreateNewOperator(command.Operator);

        dbContext.Operators.Add(operatorN);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateOperatorResult(operatorN.Id);
    }

    private static Operator CreateNewOperator(OperatorDto operatorDto)
    {
        var dniType = operatorDto.Dni.ToDniType();

        var dni = Dni.Of(dniType, operatorDto.Dni.Number);

        var newOperator = Operator.Create(
                id: Guid.NewGuid(),
                operatorName: Name.Of(operatorDto.Name.FirstName,operatorDto.Name.LastName),
                email: Email.Of(operatorDto.Email),
                phone: Phone.Of(operatorDto.Phone),
                dni: dni,
                password: Password.Of(operatorDto.Password)
            );

        return newOperator;
    }
}
