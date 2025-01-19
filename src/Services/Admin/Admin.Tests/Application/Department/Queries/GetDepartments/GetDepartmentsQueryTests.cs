using FluentAssertions;
using Admin.Application.Departments.Queries.GetDepartments;

namespace Admin.Tests.Application.Department.Queries.GetDepartments
{
    public class GetDepartmentsQueryTests
    {
        [Fact]
        public void GetDepartmentsQuery_ShouldInitializeCorrectly()
        {
            // Arrange
            var paginationRequest = new PaginationRequest(1, 10);

            // Act
            var query = new GetDepartmentsQuery(paginationRequest);

            // Assert
            query.PaginationRequest.Should().Be(paginationRequest);
        }

        [Fact]
        public void GetDepartmentsResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var departments = new PaginatedResult<DepartmentDto>(1, 10, 100, new List<DepartmentDto>());

            // Act
            var result = new GetDepartmentsResult(departments);

            // Assert
            result.Departments.Should().Be(departments);
        }
    }
}
