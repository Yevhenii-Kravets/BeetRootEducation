using BuisnessLogic;
using BuisnessLogic.Services;
using BusinessLogic.Tests;
using Microsoft.EntityFrameworkCore;
using Moq;
using Task = Models.Task;


namespace BuisnessLogic_Test
{
    public class TaskServiceTest
    {
        [Fact]
        public void TaskService_GetAll_WhenResultIsNotEmpty()
        {
            // Arrange
            var tasks = new List<Task>
            {
                new Task()
                {
                        Title = "Title one",
                        Description = "desc one",
                        Date = new DateTime(2023, 9, 26, 15, 30, 0),
                        Color = "#ffffff"
                },
                new Task()
                {
                        Title = "Title two",
                        Description = "desc one",
                        Date = new DateTime(2023, 9, 26, 15, 30, 0),
                        Color = "#000000"
                }
            };

            var mockSet = InitHelpers.GetQueryableMockDbSet(tasks);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Tasks).Returns(mockSet);

            var service = new TaskService(mockContext.Object);

            // Act
            var result = service.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(tasks.Count(), result.Count());
        }
        [Fact]
        public void TaskService_GetAll_WhenResultIsEmpty()
        {
            // Arrange
            var mockSet = InitHelpers.GetQueryableMockDbSet(new List<Task>());
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Tasks).Returns(mockSet);

            var service = new TaskService(mockContext.Object);

            // Act
            var result = service.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Count());
        }

        [Fact]
        public void TaskService_GetInRange_WhenResultIsNotEmpty()
        {
            // Arrange
            var tasks = new List<Task>
            {
                new Task()
                {
                        Title = "Title one",
                        Description = "desc",
                        Date = new DateTime(2010, 1, 1, 12, 0, 0),
                        Color = "#ffffff"
                },
                new Task()
                {
                        Title = "Title two",
                        Description = "desc",
                        Date = new DateTime(2000, 1, 1, 12, 0, 0),
                        Color = "#000000"
                },
                new Task()
                {
                        Title = "Title three",
                        Description = "desc",
                        Date = new DateTime(2020, 1, 1, 12, 0, 0),
                        Color = "#000000"
                },
                new Task()
                {
                        Title = "Title four",
                        Description = "desc",
                        Date = new DateTime(2030, 1, 1, 12, 0, 0),
                        Color = "#000000"
                }
            };

            var mockSet = InitHelpers.GetQueryableMockDbSet(tasks);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Tasks).Returns(mockSet);

            var service = new TaskService(mockContext.Object);

            // Act
            var result = service.GetInRange(new DateTime(2005, 1, 1, 12, 0, 0), new DateTime(2025, 1, 1, 12, 00, 0));

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void TaskService_Create_WhenDataIsNotValid()
        {
            // Arrange
            var invalidTask = new Task()
            {
                Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
                Title = "Title three",
                Description = "desc",
                Date = new DateTime(2020, 1, 1, 12, 0, 0),
                Color = "#000000"
            };
            var tasks = new List<Task>
            {
                new Task()
                {
                    Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
                        Title = "Title one",
                        Description = "desc",
                        Date = new DateTime(2010, 1, 1, 12, 0, 0),
                        Color = "#ffffff"
                }
            };

            var mockSet = InitHelpers.GetQueryableMockDbSet(tasks);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Tasks).Returns(mockSet);

            var service = new TaskService(mockContext.Object);

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => service.Create(invalidTask));
        }
        [Fact]
        public void TaskService_Create_WhenDataIsValid()
        {
            // Arrange
            var IsValidTask = new Task()
            {
                Title = "Title three",
                Description = "desc",
                Date = new DateTime(2020, 1, 1, 12, 0, 0),
                Color = "#000000"
            };
            var tasks = new List<Task>
            {
                new Task()
                {
                    Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
                        Title = "Title one",
                        Description = "desc",
                        Date = new DateTime(2010, 1, 1, 12, 0, 0),
                        Color = "#ffffff"
                },
                new Task()
                {
                        Title = "Title two",
                        Description = "desc",
                        Date = new DateTime(2000, 1, 1, 12, 0, 0),
                        Color = "#000000"
                }
            };

            var mockSet = InitHelpers.GetQueryableMockDbSet(tasks);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Tasks).Returns(mockSet);

            var service = new TaskService(mockContext.Object);

            // Act
            var result = service.Create(IsValidTask);

            // Assert
            Assert.NotEqual(Guid.Empty, result);
            Assert.True(tasks.Any(t => t.Id == result));
        }

        [Fact]
        public void TaskService_Update_WhenDataIsValid()
        {
            // Arrange
            var isValidTask = new Task()
            {
                Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
                Title = "Title three",
                Description = "desc",
                Date = new DateTime(2020, 1, 1, 12, 0, 0),
                Color = "#000000"
            };
            var tasks = new List<Task>
            {
                new Task()
                {
                    Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
                        Title = "Title one",
                        Description = "desc",
                        Date = new DateTime(2010, 1, 1, 12, 0, 0),
                        Color = "#ffffff"
                },
                new Task()
                {
                        Title = "Title two",
                        Description = "desc",
                        Date = new DateTime(2000, 1, 1, 12, 0, 0),
                        Color = "#000000"
                }
            };

            var mockSet = InitHelpers.GetQueryableMockDbSet(tasks);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Tasks).Returns(mockSet);

            var service = new TaskService(mockContext.Object);

            // Act
            var result = service.Update(isValidTask);

            // Assert
            Assert.Equal(isValidTask.Id, result);
            var updatedTask = tasks.FirstOrDefault(t => t.Id == isValidTask.Id);
            Assert.NotNull(updatedTask);
            Assert.Equal(isValidTask.Title, updatedTask.Title);
        }
        [Fact]
        public void TaskService_Update_WhenDataIsNotValid()
        {
            // Arrange
            var isNotValidTask = new Task()
            {
                Title = "Title three",
                Description = "desc",
                Date = new DateTime(2020, 1, 1, 12, 0, 0),
                Color = "#000000"
            };
            var tasks = new List<Task>
            {
                new Task()
                {
                    Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
                        Title = "Title one",
                        Description = "desc",
                        Date = new DateTime(2010, 1, 1, 12, 0, 0),
                        Color = "#ffffff"
                },
                new Task()
                {
                        Title = "Title two",
                        Description = "desc",
                        Date = new DateTime(2000, 1, 1, 12, 0, 0),
                        Color = "#000000"
                }
            };

            var mockSet = InitHelpers.GetQueryableMockDbSet(tasks);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Tasks).Returns(mockSet);

            var service = new TaskService(mockContext.Object);

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => service.Update(isNotValidTask));
        }

        [Fact]
        public void TaskService_Delete_WhenDataIsNotValid()
        {
            // Arrange
            var isNotValidGuid = Guid.NewGuid();

            var tasks = new List<Task>
            {
                new Task()
                {
                    Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
                        Title = "Title one",
                        Description = "desc",
                        Date = new DateTime(2010, 1, 1, 12, 0, 0),
                        Color = "#ffffff"
                },
                new Task()
                {
                        Title = "Title two",
                        Description = "desc",
                        Date = new DateTime(2000, 1, 1, 12, 0, 0),
                        Color = "#000000"
                }
            };

            var mockSet = InitHelpers.GetQueryableMockDbSet(tasks);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Tasks).Returns(mockSet);

            var service = new TaskService(mockContext.Object);

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => service.Delete(isNotValidGuid));
        }
        [Fact]
        public void TaskService_Delete_WhenDataIsValid()
        {
            // Arrange
            var isValidGuid = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411");

            var tasks = new List<Task>
            {
        new Task()
        {
            Id = new Guid("c71c1f08-70a1-4e0a-9e3a-764f7f3e5411"),
            Title = "Title one",
            Description = "desc",
            Date = new DateTime(2010, 1, 1, 12, 0, 0),
            Color = "#ffffff"
        },
        new Task()
        {
            Title = "Title two",
            Description = "desc",
            Date = new DateTime(2000, 1, 1, 12, 0, 0),
            Color = "#000000"
        }
    };

            var mockSet = InitHelpers.GetQueryableMockDbSet(tasks);
            var mockContext = InitHelpers.GetDbContext();
            mockContext.Setup(m => m.Tasks).Returns(mockSet);

            var service = new TaskService(mockContext.Object);

            // Act
            var result = service.Delete(isValidGuid);

            // Assert
            Assert.Equal(isValidGuid, result);
        }
    }
}