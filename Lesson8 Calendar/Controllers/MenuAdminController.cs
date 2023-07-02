

using Scheme;

namespace Controllers
{
    public class MenuAdminController : IController
    {
        // RW MODE
        public IController ExecuteAction()
        {
            if (!Admin.GetInstance().UserIsAdmin())
                return new StartMenuController();

            Console.Clear();
            Console.WriteLine("admin mode"
                          + "\n 1. Show meetings"
                          + "\n 2. Add meeting"
                          + "\n 3. Update meeting"
                          + "\n 4. Remove meetings"

                          + "\n 5. Show rooms"
                          + "\n 6. Add room"
                          + "\n 7. Update room"
                          + "\n 8. Remove room"

                          + "\n 9. Show meetings from room"
                          + "\n 0. Exit"
                          );

            var keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.D0: return null;

                case ConsoleKey.D1: return new MeetingsShowController(this);
                case ConsoleKey.D2: return new MeetingAddController();
                case ConsoleKey.D3: return new MeetingUpdateController();
                case ConsoleKey.D4: return new MeetingRemoveController();

                case ConsoleKey.D5: return new RoomsShowController(this);
                case ConsoleKey.D6: return new RoomAddController();
                case ConsoleKey.D7: return new RoomUpdateController();
                case ConsoleKey.D8: return new RoomRemoveController();

                case ConsoleKey.D9: return new ShowMeetingsFromRoomController(this);

                default: return new MenuAdminController();
            }
        }
        

    }
}
