using BuildingBlocks.Messaging.Events;
using MassTransit;
using Providers.Application.Drivers.Commands.UpdateDriverStatus;

namespace Providers.Application.Drivers.EventHandlers.Integration
{
    public class OrderProgressUpdatedEventHandler
    (ISender sender, ILogger<OrderProgressUpdatedEventHandler> logger)
    : IConsumer<OrderProgressUpdatedEvent>
    {
        public async Task Consume(ConsumeContext<OrderProgressUpdatedEvent> context)
        {
            // Update order status
            logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

            var command = MapToUpdateDriverStatusCommand(context.Message);
            await sender.Send(command);
        }

        private static UpdateDriverStatusCommand MapToUpdateDriverStatusCommand(OrderProgressUpdatedEvent message)
        {
            var locationDto = new LocationDto(
                Address1: message.AddressLine1,
                Address2: message.AddressLine2,
                Zip: message.Zip,
                State: message.State,
                City: message.City,
                Coordinates: new CoordinatesDto(message.Latitude, message.Longitude)
                );
                
            var updateStatusDto = new UpdateStatusDto(message.DriverId, message.Status, locationDto);
            return new UpdateDriverStatusCommand(updateStatusDto);
        }
    }
}
