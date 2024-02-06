using BuisnessLogic;
using BuisnessLogic.Interfaces;
using Calendar.Controllers;
using Calendar.Models;
using Moq;
using Task = Models.Task;

namespace Controllers.Tests
{
    public class TaskControllerTests
    {
        [Fact]
        public void TaskController_Create_WhenDataIsValid()
        {
            // Arrange
            var logger = new Mock<Microsoft.Extensions.Logging.ILogger<TaskController>>();
            var context = InitHelpers.GetDbContext();
            var taskService = new Mock<IServiceItem<Task>>();
            var validator = new TaskRequestModelValidator();
            var service = new TaskController(logger.Object, context.Object, taskService.Object, validator);

            //Act
            var result = service.Create(new TaskRequestModel()
            {
                Title = "task",
                Description = "desc",
                Date = DateTime.Now,
                Color = "#ffffff"
            });

            //Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("Task title")]
        public void TaskController_Create_WithValidTitle_ReturnsNoError(string taskTitle)
        {
            // Arrange
            var logger = new Mock<Microsoft.Extensions.Logging.ILogger<TaskController>>();
            var context = InitHelpers.GetDbContext();
            var taskService = new Mock<IServiceItem<Task>>();
            var validator = new TaskRequestModelValidator();
            var service = new TaskController(logger.Object, context.Object, taskService.Object, validator);

            //Act
            var result = service.Create(new TaskRequestModel()
            {
                Title = taskTitle,
                Description = "desc",
                Date = DateTime.Now,
                Color = "#ffffff"
            });

            //Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("12")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("123456789012345678901234567890 invalid")]
        public void TaskController_Create_WithInvalidTitle_ReturnsError(string taskTitle)
        {
            // Arrange
            var model = new TaskRequestModel()
            {
                Title = taskTitle,
                Description = "desc",
                Date = DateTime.Now,
                Color = "#ffffff"
            };

            var logger = new Mock<Microsoft.Extensions.Logging.ILogger<TaskController>>();
            var context = InitHelpers.GetDbContext();
            var taskService = new Mock<IServiceItem<Task>>();

            var validator = new TaskRequestModelValidator();
            var service = new TaskController(logger.Object, context.Object, taskService.Object, validator);

            //Act
            var result = service.Create(model);

            //Assert
            Assert.NotNull(result);

            var validationResult = validator.Validate(model);

            Assert.NotNull(validationResult);
            Assert.False(validationResult.IsValid);
        }

    }
}