using BuisnessLogic.Interfaces;
using Calendar.Controllers;
using Calendar.Models;
using Models;
using Moq;

namespace Controllers.Tests
{
    public class EventControllerTests
    {
        [Fact]
        public void EventController_Create_WhenDataIsValid()
        {
            // Arrange
            var logger = new Mock<Microsoft.Extensions.Logging.ILogger<EventController>>();
            var context = InitHelpers.GetDbContext();
            var eventService = new Mock<IServiceItem<Event>>();
            var validator = new EventRequestModelValidator();
            var service = new EventController(logger.Object, context.Object, eventService.Object, validator);

            //Act
            var result = service.Create(new EventRequestModel()
            {
                Title = "event",
                Description = "desc",
                StartDate = new DateTime(2023, 1, 1, 12, 0, 0),
                EndDate = new DateTime(2023, 1, 2, 12, 0, 0),
                Theme = new EventRequestModel.EventRequestModelTheme() { },
                Repeat = new EventRequestModel.EventRequestModelRepeat() { }
            });

            //Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("Event title")]
        [InlineData("Event title")]
        [InlineData("Event title")]
        [InlineData("Event title")]
        [InlineData("Event title")]
        [InlineData("Event title")]
        public void EventController_Create_WithValidTitle_ReturnsNoError(string eventTitle)
        {
            // Arrange
            var logger = new Mock<Microsoft.Extensions.Logging.ILogger<EventController>>();
            var context = InitHelpers.GetDbContext();
            var eventService = new Mock<IServiceItem<Event>>();
            var validator = new EventRequestModelValidator();
            var service = new EventController(logger.Object, context.Object, eventService.Object, validator);

            //Act
            var result = service.Create(new EventRequestModel()
            {
                Title = eventTitle,
                Description = "desc",
                StartDate = new DateTime(2023, 1, 1, 12, 0, 0),
                EndDate = new DateTime(2023, 1, 2, 12, 0, 0),
                Theme = new EventRequestModel.EventRequestModelTheme() { },
                Repeat = new EventRequestModel.EventRequestModelRepeat() { }
            });

            //Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("12")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("123456789012345678901234567890 invalid")]
        public void EventController_Create_WithInvalidTitle_ReturnsError(string eventTitle)
        {
            // Arrange
            var model = new EventRequestModel()
            {
                Title = eventTitle,
                Description = "desc",
                StartDate = new DateTime(2023, 1, 1, 12, 0, 0),
                EndDate = new DateTime(2023, 1, 2, 12, 0, 0),
                Theme = new EventRequestModel.EventRequestModelTheme() { },
                Repeat = new EventRequestModel.EventRequestModelRepeat() { }
            };

            var logger = new Mock<Microsoft.Extensions.Logging.ILogger<EventController>>();
            var context = InitHelpers.GetDbContext();
            var eventService = new Mock<IServiceItem<Event>>();

            var validator = new EventRequestModelValidator();
            var service = new EventController(logger.Object, context.Object, eventService.Object, validator);

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