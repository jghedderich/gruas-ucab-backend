using FluentAssertions;
using FluentValidation.TestHelper;
using Admin.Application.Departments.Commands.UpdateDepartment;

namespace Admin.Tests.Application.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandTests
    {
        [Fact]
        public void UpdateDepartmentCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var departmentDto = new DepartmentDto(Guid.NewGuid(), "HR", "Human Resources", true);

            // Act
            var command = new UpdateDepartmentCommand(departmentDto);

            // Assert
            command.Department.Should().Be(departmentDto);
        }

        [Fact]
        public void UpdateDepartmentResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new UpdateDepartmentResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }

        [Fact]
        public void UpdateDepartmentCommandValidator_ShouldHaveValidationError_WhenDepartmentNameIsEmpty()
        {
            // Arrange
            var validator = new UpdateDepartmentCommandValidator();
            var departmentDto = new DepartmentDto(Guid.NewGuid(), null, "Human Resources", true);
            var command = new UpdateDepartmentCommand(departmentDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Department.DepartmentName).WithErrorMessage("Department name es requerido");
        }

        [Fact]
        public void UpdateDepartmentCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new UpdateDepartmentCommandValidator();
            var departmentDto = new DepartmentDto(Guid.NewGuid(), "HR", "Human Resources", true);
            var command = new UpdateDepartmentCommand(departmentDto);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Department.DepartmentName);
        }
    }
}
