using BuisnessLogic;
using BuisnessLogic.Services;
using BusinessLogic.Tests;
using Microsoft.EntityFrameworkCore;
using Moq;
using Models;


namespace BuisnessLogic_Test
{
    public class EventServiceTest
    {
        [Fact]
        public void EventService_GetAll_WhenResultIsNotEmpty()
        {
            var theme = new EventTheme() { Name = "Default" };
            var repeat = new EventRepeat() { };
            // Arrange
            var events = new List<Event>
            {
                new Event()
                {
                    Title = "Event 1",
                    Description = "test",
                    StartDate = new DateTime(2023, 9, 26, 15, 30, 0),
                    EndDate = new DateTime(2023, 9, 27, 15, 30, 0),
                    Theme = theme,
                    Repeat = repeat
                },
                new Event()
                {
                    Title = "Event 2",
                    Description = "test",
                    StartDate = new DateTime(2023, 8, 26, 15, 30, 0),
                    EndDate = new DateTime(2023, 9, 27, 15, 30, 0),
                    Theme = theme,
                    Repeat = repeat
                },
            };

            var mockSet = InitHelpers.GetQueryableMockDbSet(events);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Events).Returns(mockSet);

            var service = new EventService(mockContext.Object);

            // Act
            var result = service.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(events.Count(), result.Count());
        }
        
        [Fact]
        public void TaskService_GetAll_WhenResultIsEmpty()
        {
            var mockSet = InitHelpers.GetQueryableMockDbSet(new List<Event>());
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Events).Returns(mockSet);

            var service = new EventService(mockContext.Object);

            // Act
            var result = service.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Count());
        }
        
        [Fact]
        public void EventService_GetInRange_WhenResultIsNotEmpty()
        {
            // Arrange
            var theme = new EventTheme() { Name = "Default" };
            var repeat = new EventRepeat() { };
           
            var events = new List<Event>
            {
                new Event()
                {
                    Title = "Event 1",
                    Description = "test",
                    StartDate = new DateTime(2001, 9, 26, 15, 30, 0),
                    EndDate = new DateTime(2004, 9, 27, 15, 30, 0),
                    Theme = theme,
                    Repeat = repeat
                },
                new Event()
                {
                    Title = "Event 2",
                    Description = "test",
                    StartDate = new DateTime(2002, 8, 26, 15, 30, 0),
                    EndDate = new DateTime(2026, 9, 27, 15, 30, 0),
                    Theme = theme,
                    Repeat = repeat
                },
                new Event()
                {
                    Title = "Event 3",
                    Description = "test",
                    StartDate = new DateTime(2020, 8, 26, 15, 30, 0),
                    EndDate = new DateTime(2026, 9, 27, 15, 30, 0),
                    Theme = theme,
                    Repeat = repeat
                },
                new Event()
                {
                    Title = "Event 4",
                    Description = "test",
                    StartDate = new DateTime(2026, 8, 26, 15, 30, 0),
                    EndDate = new DateTime(2027, 9, 27, 15, 30, 0),
                    Theme = theme,
                    Repeat = repeat
                },
            };

            var mockSet = InitHelpers.GetQueryableMockDbSet(events);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Events).Returns(mockSet);

            var service = new EventService(mockContext.Object);

            // Act
            var result = service.GetInRange(new DateTime(2005, 1, 1, 12, 0, 0), new DateTime(2025, 1, 1, 12, 0, 0));

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        
        [Fact]
        public void EventService_Create_WhenDataIsNotValid()
        {
            // Arrange
            var theme = new EventTheme() { Name = "Default" };
            var repeat = new EventRepeat() { };

            var isNotValidEvent = new Event()
            {
                Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
                Title = "Event 2",
                Description = "test",
                StartDate = new DateTime(2002, 8, 26, 15, 30, 0),
                EndDate = new DateTime(2026, 9, 27, 15, 30, 0),
                Theme = theme,
                Repeat = repeat
            };

            var events = new List<Event>
            {
                new Event()
                {
                    Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
                    Title = "Event 1",
                    Description = "test",
                    StartDate = new DateTime(2001, 9, 26, 15, 30, 0),
                    EndDate = new DateTime(2004, 9, 27, 15, 30, 0),
                    Theme = theme,
                    Repeat = repeat
                }
            };

            var mockSet = InitHelpers.GetQueryableMockDbSet(events);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Events).Returns(mockSet);

            var service = new EventService(mockContext.Object);

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => service.Create(isNotValidEvent));
        }
        
        [Fact]
        public void EventService_Create_WhenDataIsValid()
        {
            // Arrange
            var theme = new EventTheme() { Name = "Default" };
            var repeat = new EventRepeat() { };

            var isValidEvent = new Event()
            {
                Title = "Event 2",
                Description = "test",
                StartDate = new DateTime(2002, 8, 26, 15, 30, 0),
                EndDate = new DateTime(2026, 9, 27, 15, 30, 0),
                Theme = theme,
                Repeat = repeat
            };

            var events = new List<Event>
            {
                new Event()
                {
                    Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
                    Title = "Event 1",
                    Description = "test",
                    StartDate = new DateTime(2001, 9, 26, 15, 30, 0),
                    EndDate = new DateTime(2004, 9, 27, 15, 30, 0),
                    Theme = theme,
                    Repeat = repeat
                }
            };

            var mockSet = InitHelpers.GetQueryableMockDbSet(events);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Events).Returns(mockSet);

            var service = new EventService(mockContext.Object);

            // Act
            var result = service.Create(isValidEvent);

            // Assert
            Assert.Equal(isValidEvent.Id, result);
            var updatedTask = events.FirstOrDefault(t => t.Id == isValidEvent.Id);
            Assert.NotNull(updatedTask);
            Assert.Equal(isValidEvent.Title, updatedTask.Title);
        }
        
        [Fact]
        public void EventService_Update_WhenDataIsNotValid()
        {
            // Arrange
            var theme = new EventTheme() { Name = "Default" };
            var repeat = new EventRepeat() { };

            var isNotValidEvent = new Event()
            {
                Title = "Event 2",
                Description = "test",
                StartDate = new DateTime(2002, 8, 26, 15, 30, 0),
                EndDate = new DateTime(2026, 9, 27, 15, 30, 0),
                Theme = theme,
                Repeat = repeat
            };

            var events = new List<Event>
            {
                new Event()
                {
                    Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
                    Title = "Event 1",
                    Description = "test",
                    StartDate = new DateTime(2001, 9, 26, 15, 30, 0),
                    EndDate = new DateTime(2004, 9, 27, 15, 30, 0),
                    Theme = theme,
                    Repeat = repeat
                }
            };

            var mockSet = InitHelpers.GetQueryableMockDbSet(events);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Events).Returns(mockSet);

            var service = new EventService(mockContext.Object);

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => service.Update(isNotValidEvent));
        }

        [Fact]
        public void EventService_Update_WhenDataIsValid()
        {
            // Arrange
            var theme = new EventTheme() { Name = "Default" };
            var repeat = new EventRepeat() { };

            var isValidEvent = new Event()
            {
                Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
                Title = "Event 2",
                Description = "test",
                StartDate = new DateTime(2002, 8, 26, 15, 30, 0),
                EndDate = new DateTime(2026, 9, 27, 15, 30, 0),
                Theme = theme,
                Repeat = repeat
            };

            var events = new List<Event>
            {
                new Event()
                {
                    Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
                    Title = "Event 1",
                    Description = "test",
                    StartDate = new DateTime(2001, 9, 26, 15, 30, 0),
                    EndDate = new DateTime(2004, 9, 27, 15, 30, 0),
                    Theme = theme,
                    Repeat = repeat
                }
            };

            var mockSet = InitHelpers.GetQueryableMockDbSet(events);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Events).Returns(mockSet);

            var service = new EventService(mockContext.Object);

            // Act
            var result = service.Update(isValidEvent);

            // Assert
            Assert.Equal(isValidEvent.Id, result);
            var updatedEvent = events.FirstOrDefault(t => t.Id == isValidEvent.Id);
            Assert.NotNull(updatedEvent);
            Assert.Equal(isValidEvent.Title, updatedEvent.Title);
        }

        [Fact]
        public void EventService_Delete_WhenDataIsNotValid()
        {
            // Arrange
            var isNotValidGuid = Guid.NewGuid();

            // Arrange
            var theme = new EventTheme() { Name = "Default" };
            var repeat = new EventRepeat() { };

            var events = new List<Event>
            {
                new Event()
                {
                    Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
                    Title = "Event 1",
                    Description = "test",
                    StartDate = new DateTime(2001, 9, 26, 15, 30, 0),
                    EndDate = new DateTime(2004, 9, 27, 15, 30, 0),
                    Theme = theme,
                    Repeat = repeat
                }
            };

            var mockSet = InitHelpers.GetQueryableMockDbSet(events);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Events).Returns(mockSet);

            var service = new EventService(mockContext.Object);

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => service.Delete(isNotValidGuid));
        }
        [Fact]
        public void EventService_Delete_WhenDataIsValid()
        {
            // Arrange
            var isValidGuid = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411");

            // Arrange
            var theme = new EventTheme() { Name = "Default" };
            var repeat = new EventRepeat() { };

            var events = new List<Event>
            {
                new Event()
                {
                    Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
                    Title = "Event 1",
                    Description = "test",
                    StartDate = new DateTime(2001, 9, 26, 15, 30, 0),
                    EndDate = new DateTime(2004, 9, 27, 15, 30, 0),
                    Theme = theme,
                    Repeat = repeat
                }
            };

            var mockSet = InitHelpers.GetQueryableMockDbSet(events);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Events).Returns(mockSet);

            var service = new EventService(mockContext.Object);

            // Act
            var result = service.Delete(isValidGuid);

            // Assert
            Assert.Equal(isValidGuid, result);
        }

    }
}