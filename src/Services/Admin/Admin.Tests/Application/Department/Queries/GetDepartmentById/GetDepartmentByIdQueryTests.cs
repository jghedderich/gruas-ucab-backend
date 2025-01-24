using FluentAssertions;
using Admin.Application.Departments.Queries.GetDepartmentById;

namespace Admin.Tests.Application.Department.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQueryTests
    {
        [Fact]
        public void GetDepartmentByIdQuery_ShouldInitializeCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var query = new GetDepartmentByIdQuery(id);

            // Assert
            query.Id.Should().Be(id);
        }

        [Fact]
        public void GetDepartmentByIdResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var departmentDto = new DepartmentDto(Guid.NewGuid(), "HR", "Human Resources", true);

            // Act
            var result = new GetDepartmentByIdResult(departmentDto);

            // Assert
            result.Department.Should().Be(departmentDto);
        }
    }
}
