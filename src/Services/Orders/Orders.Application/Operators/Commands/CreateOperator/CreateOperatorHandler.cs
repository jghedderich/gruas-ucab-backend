using BuildingBlocks.Emails;
using BuildingBlocks.Hashing;

namespace Orders.Application.Operators.Commands.CreateOperator;

public class CreateOperatorHandler(IApplicationDbContext dbContext, IPasswordHasher passwordHasher, IEmailSender emailSender) 
    : ICommandHandler<CreateOperatorCommand, CreateOperatorResult>
{
    public async Task<CreateOperatorResult> Handle(CreateOperatorCommand command, CancellationToken cancellationToken)
    {
        var newOperator = CreateNewOperator(command.Operator);

        dbContext.Operators.Add(newOperator);
        await dbContext.SaveChangesAsync(cancellationToken);

        await emailSender.SendEmailAsync(
            newOperator.Email.Value,
            "Se ha creado su cuenta de Operador",
            $"Su clave temporal: {command.Operator.Password}. " +
            $"Ingrese al portal web de Grúas UCAB con sus credenciales y clave temporal. " +
            $"Recuerde cambiar la clave a una de su preferencia.");

        return new CreateOperatorResult(newOperator.Id);
    }

    private Operator CreateNewOperator(OperatorDto operatorDto)
    {
        var dniType = operatorDto.Dni.ToDniType();

        var dni = Dni.Of(dniType, operatorDto.Dni.Number);

        var newOperator = Operator.Create(
                id: Guid.NewGuid(),
                operatorName: Name.Of(operatorDto.Name.FirstName,operatorDto.Name.LastName),
                email: Email.Of(operatorDto.Email!),
                phone: Phone.Of(operatorDto.Phone!),
                dni: dni,
                password: Password.Of(passwordHasher.Hash(operatorDto.Password!))
            );

        return newOperator;
    }
}
