using FluentAssertions;
using Admin.Application.Administrators.Queries.GetAdministratorById;

namespace Admin.Tests.Application.Administrators.Queries.GetAdministratorById
{
    public class GetAdministratorByIdQueryTests
    {
        [Fact]
        public void GetAdministratorByIdQuery_ShouldInitializeCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var query = new GetAdministratorByIdQuery(id);

            // Assert
            query.Id.Should().Be(id);
        }

        [Fact]
        public void GetAdministratorByIdResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var administratorDto = new AdministratorDto(Guid.NewGuid(), new NameDto("John", "Doe"), "john.doe@example.com", "password");

            // Act
            var result = new GetAdministratorByIdResult(administratorDto);

            // Assert
            result.Administrator.Should().Be(administratorDto);
        }
    }
}
