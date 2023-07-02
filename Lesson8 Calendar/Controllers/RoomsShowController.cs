using Scheme;

namespace Controllers
{
    public class RoomsShowController : IController
    {
        private IController? previousController;
        public RoomsShowController(IController controller = null)
        {
            previousController = controller;
        }

        public IController ExecuteAction()
        {
            Console.Clear();
            Console.WriteLine("Rooms: ");

            var roomsCount = Calendar.GetInstance().GetRooms().Count;
            if (roomsCount <= 0)
                Console.WriteLine("Rooms not found");
            else
                foreach (var room in Calendar.GetInstance().GetRooms())
                    Console.WriteLine($"\n{room.Name}"
                        + $"\nSeats: {room.Seats}\n");

            var keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                default: return (previousController == null ? new MenuController() : previousController);
            }
        }
    }
}
