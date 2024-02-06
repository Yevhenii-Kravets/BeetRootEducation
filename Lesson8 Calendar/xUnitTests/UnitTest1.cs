using Controllers;
using Scheme;

namespace xUnitTests
{
    public class UnitTests
    {
        [Fact]
        public void Test1()
        {
            var sut = new MeetingAddController();

            var nextController = sut.ExecuteAction();

            Assert.NotNull(nextController);
            Assert.IsType<MenuAdminController>(nextController);
        }

        [Fact]
        public void AddMeeting_ValidData_Success()
        {
            // Arrange
            var calendar = Calendar.GetInstance();
            var roomName = "Meeting Room 1";
            var roomSeats = 10;
            calendar.AddRoom(roomName, roomSeats);

            // Подготавливаем входные данные для теста
            Guid guid = Guid.NewGuid();
            string name = "Team Meeting";
            TimeSpan duration = new TimeSpan(1, 0, 0);
            DateTime startTime = DateTime.Now.AddHours(1);

            // Act
            calendar.AddMeeting(guid, name, roomName, duration, startTime);

            // Assert
            var meetings = calendar.GetMeetings();
            Assert.Single(meetings);
            var addedMeeting = meetings[0];
            Assert.Equal(guid, addedMeeting.ID);
            Assert.Equal(name, addedMeeting.Name);
            Assert.Equal(roomName, addedMeeting.Room.Name);
            Assert.Equal(roomSeats, addedMeeting.Room.Seats);
            Assert.Equal(duration, addedMeeting.Duration);
            Assert.Equal(startTime, addedMeeting.StartTime);
        }
    }
}