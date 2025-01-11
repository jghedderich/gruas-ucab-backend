using BuildingBlocks.Messaging.Events;
using MassTransit;
using Providers.Application.Drivers.Commands.AssignDriver;

namespace Providers.Application.Drivers.EventHandlers.Integration
{

    public class DriverAssignedEventHandler
    (ISender sender, ILogger<DriverAssignedEventHandler> logger)
    : IConsumer<DriverAssignedEvent>
    {
        public async Task Consume(ConsumeContext<DriverAssignedEvent> context)
        {
            // Update order status
            logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

            var command = MapToAssignDriverCommand(context.Message);
            await sender.Send(command);
        }

        private static AssignDriverCommand MapToAssignDriverCommand(DriverAssignedEvent message)
        {
            var updateStatusDto = new AssignDriverDto(message.OrderId, message.DriverId);
            return new AssignDriverCommand(updateStatusDto);
        }
    }
}
