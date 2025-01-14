using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Providers.API.Endpoints.Drivers;
using Providers.Application.Data;
using Providers.Application.Drivers.Queries.GetDrivers;
using Providers.Domain.Models;

namespace Providers.Tests.API.Endpoints.Drivers
{
    public class GetDriversTests
    {
        private readonly Mock<ISender> _mockSender;
        private readonly Mock<IApplicationDbContext> _mockContext;

        public GetDriversTests()
        {
            _mockSender = new Mock<ISender>();
            _mockContext = new Mock<IApplicationDbContext>();
        }

        [Fact]
        public async Task GetDrivers_ReturnsExpectedResult_WithValidRequest()
        {
            // Arrange
            var paginationRequest = new PaginationRequest { PageIndex = 1, PageSize = 10 };

            var driverDtos = new List<DriverDto>
            {
                new(
                    Id: Guid.NewGuid(),
                    VehicleId: Guid.NewGuid(),
                    ProviderId: Guid.NewGuid(),
                    Name: new NameDto("testFirst1", "testLast1"),
                    Dni: new DniDto("V", "123456789"),
                    Phone: "04121234567",
                    Email: "first@test.com",
                    Password: "123456",
                    Status: "Available",
                    Location: new LocationDto(
                        "Address1", "Address2", "1060",
                        "Miranda", "Caracas",
                        new CoordinatesDto("10.664", "-66.325")),
                    Token: "some-test-token",
                    IsActive: true
                ),
                new(
                    Id: Guid.NewGuid(),
                    VehicleId: Guid.NewGuid(),
                    ProviderId: Guid.NewGuid(),
                    Name: new NameDto("testFirst2", "testLast2"),
                    Dni: new DniDto("V", "123456789"),
                    Phone: "04121234567",
                    Email: "second@test.com",
                    Password: "123456",
                    Status: "Available",
                    Location: new LocationDto(
                        "Address1", "Address2", "1060", 
                        "Miranda", "Caracas", 
                        new CoordinatesDto("10.664", "-66.325")),
                    Token: "some-test-token",
                    IsActive: true
                ),
            };

            var mockDbSet = new Mock<DbSet<Driver>>();

            _mockContext.Setup(c => c.Drivers).Returns(mockDbSet.Object);

            var paginatedResult = new PaginatedResult<DriverDto>(paginationRequest.PageIndex, paginationRequest.PageSize, driverDtos.Count, driverDtos);
            var expectedResponse = new GetDriversResult(paginatedResult);

            // Mocking the sender to return the paginated result
            _mockSender.Setup(sender => sender.Send(It.IsAny<GetDriversQuery>(), It.IsAny<CancellationToken>()))
                       .ReturnsAsync(new GetDriversResult(paginatedResult));

            // Act
            var handler = new GetDriversHandler(_mockContext.Object);
            var result = await handler.Handle(new GetDriversQuery(paginationRequest), CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(new GetDriversResult(paginatedResult));
        }
    }
}
