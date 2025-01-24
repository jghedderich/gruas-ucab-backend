using Moq;
using Orders.Application.CostDetails.Commands.UpdateCostDetailStatus;
using Orders.Application.Data;
using Orders.Application.Dtos;
using Orders.Application.Exceptions;
using Orders.Domain.Models;
using Orders.Domain.ValueObjects;
using Xunit;
using Assert = Xunit.Assert; // Alias para Xunit.Assert

namespace Orders.Tests.Application.CostDetailsTest.CommandsTest.UpdateCostDetailStatusTest
{
    public class UpdateCostDetailStatusHandlerTests
    {
        private readonly Mock<IApplicationDbContext> _mockDbContext;
        private readonly UpdateCostDetailStatusHandlerI _handler;

        public UpdateCostDetailStatusHandlerTests()
        {
            _mockDbContext = new Mock<IApplicationDbContext>();
            _handler = new UpdateCostDetailStatusHandlerI(_mockDbContext.Object);
        }

        [Fact]
        public async Task Handle_ShouldThrowCostDetailNotFoundException_WhenCostDetailDoesNotExist()
        {
            // Arrange
            var command = new UpdateCostDetailStatusCommand(new UpdateStatusCostDetailDto(
                Guid.NewGuid(),
                "Completed"));

            _mockDbContext.Setup(db => db.CostDetails.FindAsync(new object[] { command.CostDetail.Id }, It.IsAny<CancellationToken>()))
                          .ReturnsAsync((CostDetail)null);

            // Act & Assert
            await Assert.ThrowsAsync<CostDetailNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldUpdateCostDetailStatus_WhenCostDetailExists()
        {
            // Arrange
            var status = Enum.Parse<StatusCO>("Pending", true);
            var existingCostDetail = CostDetail.Create(Guid.NewGuid(), Guid.NewGuid(), "Description", 100, CostDetailStatus.Of(status));
            var command = new UpdateCostDetailStatusCommand(new UpdateStatusCostDetailDto(
                existingCostDetail.Id,
                "Approved"));

            _mockDbContext.Setup(db => db.CostDetails.FindAsync(new object[] { command.CostDetail.Id }, It.IsAny<CancellationToken>()))
                          .ReturnsAsync(existingCostDetail);

            _mockDbContext.Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("Approved", existingCostDetail.StatusC.StatusCO.ToString());

            _mockDbContext.Verify(db => db.CostDetails.Update(existingCostDetail), Times.Once);
            _mockDbContext.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
