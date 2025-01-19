using FluentAssertions;
using Admin.Application.Administrators.Queries.GetAdministrators;

namespace Admin.Tests.Application.Administrators.Queries.GetAdministrators
{
    public class GetAdministratorsQueryTests
    {
        [Fact]
        public void GetAdministratorsQuery_ShouldInitializeCorrectly()
        {
            // Arrange
            var paginationRequest = new PaginationRequest(1, 10);

            // Act
            var query = new GetAdministratorsQuery(paginationRequest);

            // Assert
            query.PaginationRequest.Should().Be(paginationRequest);
        }

        [Fact]
        public void GetAdministratorsResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var administrators = new PaginatedResult<AdministratorDto>(1, 10, 100, new List<AdministratorDto>());

            // Act
            var result = new GetAdministratorsResult(administrators);

            // Assert
            result.Administrators.Should().Be(administrators);
        }
    }
}
