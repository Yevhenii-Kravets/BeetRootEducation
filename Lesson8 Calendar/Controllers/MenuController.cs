using Scheme;

namespace Controllers
{
    public class MenuController : IController
    {
        // READONLY MODE
        public IController ExecuteAction()
        {
            Console.Clear();
            Console.WriteLine("readonly mode"
                          + "\n 1. Show meetings"
                          + "\n 2. Show rooms"
                          + "\n 3. Show meetings from room"
                          + "\n 0. Exit"
                          );

            var keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.D0: return null;
                case ConsoleKey.D1: return new MeetingsShowController();
                case ConsoleKey.D2: return new RoomsShowController();
                case ConsoleKey.D3: return new ShowMeetingsFromRoomController();

                default: return new MenuController();
            }
        }
    }
}