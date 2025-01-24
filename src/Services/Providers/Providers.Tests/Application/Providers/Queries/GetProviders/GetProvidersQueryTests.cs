using FluentAssertions;
using Providers.Application.Providers.Queries.GetProviders;
using BuildingBlocks.Pagination;

namespace Providers.Tests.Application.Providers.Queries.GetProviders
{
    public class GetProvidersQueryTests
    {
        [Fact]
        public void GetProvidersQuery_ShouldInitializeCorrectly()
        {
            // Arrange
            var paginationRequest = new PaginationRequest(1, 10);

            // Act
            var query = new GetProvidersQuery(paginationRequest);

            // Assert
            query.PaginationRequest.Should().Be(paginationRequest);
        }

        [Fact]
        public void GetProvidersResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var providers = new PaginatedResult<ProviderDto>(1, 10, 100, new List<ProviderDto>());

            // Act
            var result = new GetProvidersResult(providers);

            // Assert
            result.Providers.Should().Be(providers);
        }
    }
}
