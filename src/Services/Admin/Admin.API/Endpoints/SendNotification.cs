using Admin.Infrastructure.Settings;
using FirebaseAdmin.Messaging;
using Hangfire;

namespace Admin.API.Endpoints;

public record SendNotificationRequest(string DeviceToken, string Title, string Body, string Time);
public record SendNotificationResponse(bool IsSuccess, string? ErrorMessage);

public class SendNotification : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/notifications/send", (SendNotificationRequest request) =>
        {
            try
            {
                // Programa un trabajo en Hangfire para enviar la notificación después del tiempo especificado
                BackgroundJob.Schedule(() => SendNotificationJob(request), TimeSpan.Parse(request.Time));

                var response = new SendNotificationResponse(true, null);
                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                var response = new SendNotificationResponse(false, ex.Message);
                return Results.Problem(response.ErrorMessage, statusCode: StatusCodes.Status500InternalServerError);
            }
        })
        .WithName("SendNotification")
        .Produces<SendNotificationResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Send Notification")
        .WithDescription("Schedule a push notification to be sent after a specific time.");
    }

    // Método que será ejecutado por Hangfire
    [AutomaticRetry(Attempts = 3)] // Retries en caso de error
    public static async Task SendNotificationJob(SendNotificationRequest request)
    {
        var message = new Message()
        {
            Token = request.DeviceToken,
            Notification = new Notification()
            {
                Title = request.Title,
                Body = request.Body
            }
        };

        // Enviar notificación con Firebase
        string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
        Console.WriteLine("Successfully sent message: " + response);
    }
}