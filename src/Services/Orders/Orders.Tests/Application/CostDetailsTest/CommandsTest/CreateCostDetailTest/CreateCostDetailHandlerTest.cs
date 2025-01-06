using Moq;
using Orders.Application.CostDetails.Commands.CreateCostDetail;
using Orders.Application.Data;
using Orders.Application.Dtos;
using Orders.Domain.Models;
using Orders.Domain.ValueObjects;
using Xunit;
using Assert = Xunit.Assert; // Alias para Xunit.Assert

namespace Orders.Tests.Application.CostDetailsTest.CommandsTest.CreateCostDetailTest
{
    public class CreateCostDetailHandlerTests
    {
        private readonly Mock<IApplicationDbContext> _dbContextMock;
        private readonly CreateCostDetailHandler _handler;

        public CreateCostDetailHandlerTests()
        {
            _dbContextMock = new Mock<IApplicationDbContext>();
            _handler = new CreateCostDetailHandler(_dbContextMock.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_ShouldCreateCostDetail()
        {
            // Arrange
            var costDetailDto = new CostDetailDto(
                Guid.NewGuid(), // Id
                Guid.NewGuid(), // OrderId
                "Test description", // Description
                100.50m, // Amount
                StatusCO.Pending.ToString() // StatusC
            );


            var command = new CreateCostDetailCommand(costDetailDto);

            _dbContextMock
                .Setup(db => db.CostDetails.Add(It.IsAny<CostDetail>()))
                .Verifiable();

            _dbContextMock
                .Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreateCostDetailResult>(result);
            Assert.NotEqual(Guid.Empty, result.Id);

            _dbContextMock.Verify(db => db.CostDetails.Add(It.IsAny<CostDetail>()), Times.Once);
            _dbContextMock.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidCommand_ShouldThrowNullException()
        {
            // Arrange
            var costDetailDto = new CostDetailDto(
                Guid.NewGuid(), // Id
                Guid.NewGuid(), // Invalid OrderId
                "", // Description
                0, // Amount
                StatusCO.Pending.ToString() // StatusC
            );

            var command = new CreateCostDetailCommand(costDetailDto);

            // Act & Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}