using FluentAssertions;
using FluentValidation.TestHelper;
using Admin.Application.Departments.Commands.DeleteDepartment;

namespace Admin.Tests.Application.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandTests
    {
        [Fact]
        public void DeleteDepartmentCommand_ShouldInitializeCorrectly()
        {
            // Arrange
            var departmentId = Guid.NewGuid();

            // Act
            var command = new DeleteDepartmentCommand(departmentId);

            // Assert
            command.DepartmentId.Should().Be(departmentId);
        }

        [Fact]
        public void DeleteDepartmentResult_ShouldInitializeCorrectly()
        {
            // Arrange
            var isSuccess = true;

            // Act
            var result = new DeleteDepartmentResult(isSuccess);

            // Assert
            result.IsSuccess.Should().Be(isSuccess);
        }

        [Fact]
        public void DeleteDepartmentCommandValidator_ShouldHaveValidationError_WhenDepartmentIdIsEmpty()
        {
            // Arrange
            var validator = new DeleteDepartmentCommandValidator();
            var command = new DeleteDepartmentCommand(Guid.Empty);

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.DepartmentId).WithErrorMessage("El ID del Departament es requerido");
        }

        [Fact]
        public void DeleteDepartmentCommandValidator_ShouldNotHaveValidationError_WhenCommandIsValid()
        {
            // Arrange
            var validator = new DeleteDepartmentCommandValidator();
            var command = new DeleteDepartmentCommand(Guid.NewGuid());

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.DepartmentId);
        }
    }
}
