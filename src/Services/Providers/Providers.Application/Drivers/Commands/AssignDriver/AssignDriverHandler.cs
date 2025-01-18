using BuildingBlocks.Firebase;
using System.Net.Http.Json;
using BuildingBlocks.Emails;
using System.Diagnostics.CodeAnalysis;

namespace Providers.Application.Drivers.Commands.AssignDriver;

[ExcludeFromCodeCoverage]
public class AssignDriverHandler(IApplicationDbContext dbContext, IEmailSender emailSender)
    : ICommandHandler<AssignDriverCommand, AssignDriverResult>
{
    public async Task<AssignDriverResult> Handle(AssignDriverCommand command, CancellationToken cancellationToken)
    {
        var driver = await dbContext.Drivers
            .FindAsync([command.Driver.DriverId], cancellationToken: cancellationToken) ?? throw new DriverNotFoundException(command.Driver.DriverId);

        if (driver.Token != null)
        {
            var client = new HttpClient();

            var fcmMessage = new FcmMessage
            {
                To = driver.Token,
                Priority = "high",
                Notification = new Notification
                {
                    Title = "Nueva orden asignada",
                    Body = "Ingrese a la app para mas información."
                }
            };

            var response = await client.PostAsJsonAsync("https://fcm.googleapis.com/fcm/send", fcmMessage, cancellationToken);


            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to send FCM message");
            }

        } else
        {
            await emailSender.SendEmailAsync(driver.Email.Value, "Nueva orden asignada", "Abre la app para mas información.");
        }


        return new AssignDriverResult(true);
    }
}