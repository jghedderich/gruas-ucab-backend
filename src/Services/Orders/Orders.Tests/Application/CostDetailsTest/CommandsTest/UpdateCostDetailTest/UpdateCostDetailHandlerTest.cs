
using Moq;
using Orders.Application.CostDetails.Commands.UpdateCostDetail;
using Orders.Application.Data;
using Orders.Application.Dtos;
using Orders.Application.Exceptions;
using Orders.Domain.Models;
using Orders.Domain.ValueObjects;
using Xunit;
using Assert = Xunit.Assert; // Alias para Xunit.Assert

namespace Orders.Tests.Application.CostDetailsTest.CommandsTest.UpdateCostDetailTest
{
    public class UpdateCostDetailHandlerTests
    {
        private readonly Mock<IApplicationDbContext> _mockDbContext;
        private readonly UpdateCostDetailHandler _handler;

        public UpdateCostDetailHandlerTests()
        {
            _mockDbContext = new Mock<IApplicationDbContext>();
            _handler = new UpdateCostDetailHandler(_mockDbContext.Object);
        }

        [Fact]
        public async Task Handle_ShouldThrowCostDetailNotFoundException_WhenCostDetailDoesNotExist()
        {
            // Arrange
            var command = new UpdateCostDetailCommand(new CostDetailDto(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "Test",
                100,
                "Pending"));

            _mockDbContext.Setup(db => db.CostDetails.FindAsync(new object[] { command.CostDetail.Id }, It.IsAny<CancellationToken>()))
                          .ReturnsAsync((CostDetail)null);

            // Act & Assert
            await Assert.ThrowsAsync<CostDetailNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldUpdateCostDetail_WhenCostDetailExists()
        {
            // Arrange
            var status = Enum.Parse<StatusCO>("Approved", true);
            var existingCostDetail = CostDetail.Create(Guid.NewGuid(), Guid.NewGuid(), "Old Description", 50, CostDetailStatus.Of(status));
            var command = new UpdateCostDetailCommand(new CostDetailDto(
                existingCostDetail.Id,
                Guid.NewGuid(),
                "Updated Description",
                200,
                "Approved"));

            _mockDbContext.Setup(db => db.CostDetails.FindAsync(new object[] { command.CostDetail.Id }, It.IsAny<CancellationToken>()))
                          .ReturnsAsync(existingCostDetail);

            _mockDbContext.Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("Updated Description", existingCostDetail.Description);
            Assert.Equal(200, existingCostDetail.Amount);
            Assert.Equal("Approved", existingCostDetail.StatusC.StatusCO.ToString());

            _mockDbContext.Verify(db => db.CostDetails.Update(existingCostDetail), Times.Once);
            _mockDbContext.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldCallUpdateMethod_WhenValidCommandIsProvided()
        {
            // Arrange
            var status = Enum.Parse<StatusCO>("Pending", true);
            var existingCostDetail = CostDetail.Create(Guid.NewGuid(), Guid.NewGuid(), "Old Description", 50, CostDetailStatus.Of(status));
            var command = new UpdateCostDetailCommand(new CostDetailDto(
                existingCostDetail.Id,
                Guid.NewGuid(),
                "Updated Description",
                200,
                "Completed"));

            _mockDbContext.Setup(db => db.CostDetails.FindAsync(new object[] { command.CostDetail.Id }, It.IsAny<CancellationToken>()))
                          .ReturnsAsync(existingCostDetail);

            _mockDbContext.Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockDbContext.Verify(db => db.CostDetails.Update(It.IsAny<CostDetail>()), Times.Once);
            _mockDbContext.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
