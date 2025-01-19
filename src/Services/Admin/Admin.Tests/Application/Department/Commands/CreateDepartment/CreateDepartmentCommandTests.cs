using FluentAssertions;
using FluentValidation.TestHelper;
using Admin.Application.Departament.Commands.CreateDepartament;

namespace Admin.Tests.Application.Department.Commands.CreateDepartment
{
    public class CreateDepartmentCommandTests
    {
        [Fact]
        public void CreateDepartmentCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var departmentDto = new DepartmentDto(Guid.NewGuid(), "HR", "Human Resources", true);

            // Act
            var command = new CreateDepartmentCommand(departmentDto);

            // Assert
            command.Department.Should().Be(departmentDto);
        }

        [Fact]
        public void CreateDepartmentResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var result = new CreateDepartmentResult(id);

            // Assert
            result.Id.Should().Be(id);
        }

        [Fact]
        public void CreateDepartmentCommandValidator_ShouldHaveValidationError_WhenDepartmentNameIsEmpty()
        {
            // Arrange
            var validator = new CreateDepartmentCommandValidator();
            var departmentDto = new DepartmentDto(Guid.NewGuid(), null, "Human Resources", true);
            var command = new CreateDepartmentCommand(departmentDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Department.DepartmentName).WithErrorMessage("Name is required");
        }

        [Fact]
        public void CreateDepartmentCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new CreateDepartmentCommandValidator();
            var departmentDto = new DepartmentDto(Guid.NewGuid(), "HR", "Human Resources", true);
            var command = new CreateDepartmentCommand(departmentDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Department.DepartmentName);
        }
    }
}
