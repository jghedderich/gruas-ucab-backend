using BuildingBlocks.Emails;
using Providers.Application.Settings;
using System.Diagnostics.CodeAnalysis;


namespace Providers.Application.Drivers.Commands.AssignDriver;

[ExcludeFromCodeCoverage]
public class AssignDriverHandler(
    IApplicationDbContext dbContext,
    IEmailSender emailSender,
    IFirebaseMessagingService firebaseMessagingService // This should now be recognized
) : ICommandHandler<AssignDriverCommand, AssignDriverResult>
{
    public async Task<AssignDriverResult> Handle(AssignDriverCommand command, CancellationToken cancellationToken)
    {
        // Buscar el conductor en la base de datos
        var driver = await dbContext.Drivers
            .FindAsync(new object[] { command.Driver.DriverId }, cancellationToken: cancellationToken)
            ?? throw new DriverNotFoundException(command.Driver.DriverId);

        // Verificar si el conductor tiene un token de dispositivo registrado
        if (!string.IsNullOrEmpty(driver.Token))
        {
            try
            {
                // Enviar notificación push utilizando Firebase
                await firebaseMessagingService.SendPushNotificationAsync(
                    deviceToken: driver.Token,
                    messageTitle: "Nueva orden asignada!",
                    messageBody: "Abre la app para más información."
                );
            }
            catch (Exception ex)
            {
                // Manejar errores de envío de notificación
                throw new Exception("Error al enviar notificación push al conductor.", ex);
            }
        }
        else
        {
            // Enviar un correo electrónico si no hay un token disponible
            await emailSender.SendEmailAsync(
                driver.Email.Value,
                "Nueva orden asignada",
                "Abre la app para más información."
            );
        }

        // Retornar el resultado de la asignación
        return new AssignDriverResult(true); // Fix the constructor call
    }
}
