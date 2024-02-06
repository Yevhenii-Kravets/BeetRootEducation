using Scheme;

namespace Controllers
{
    public class ShowMeetingsFromRoomController : IController
    {
        private IController? previousController;
        public ShowMeetingsFromRoomController(IController controller = null)
        {
            previousController = controller;
        }
        public IController ExecuteAction()
        {
            Console.Clear();
            var calendar = Calendar.GetInstance();
            Room room = null;

            Console.WriteLine("Enter room name:");
            var roomName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(roomName))
            {
                Console.WriteLine("Name is empty");
                Console.ReadLine();
                return (previousController == null ? new MenuController() : previousController);
            }
            else
                foreach (var rom in calendar.GetRooms())
                    if (rom.Name == roomName)
                    {
                        room = rom;
                        break;
                    }

            if (room == null)
            {
                Console.WriteLine("Room not found");
                Console.ReadLine();
                return (previousController == null ? new MenuController() : previousController);
            }

            var meetingsCount = Calendar.GetInstance().GetMeetings().Count;
            if (meetingsCount <= 0)
                Console.WriteLine("Meetings not found");
            else
                foreach (var meeting in Calendar.GetInstance().GetMeetings())
                    if (meeting.Room.Name == roomName)
                        Console.WriteLine($"\n{meeting.ID}"
                            + $"\n{meeting.Name}"
                            + $"\n{meeting.Room.Name}"
                            + $"\n{meeting.StartTime}"
                            + $"\n{meeting.Duration}"
                            );

            var keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                default: return (previousController == null ? new MenuController() : previousController);
            }
        }
    }
}
