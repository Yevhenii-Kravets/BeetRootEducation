using Scheme;

namespace Controllers
{
    public class RoomRemoveController : IController
    {
        public IController ExecuteAction()
        {
            Console.Clear();

            var calendar = Calendar.GetInstance();
            Room room = null;

            Console.Write("\nEnter the room name you want to remove: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name is empty");
                Console.ReadLine();
                return new MenuAdminController();
            }

            foreach (var rom in calendar.GetRooms())
                if (rom.Name == name)
                    room = rom;

            if (room == null)
            {
                Console.WriteLine("Room not found");
                Console.ReadLine();
                return new MenuAdminController();
            }

            calendar.RemoveRoom(room);
            Console.WriteLine("Room removed");
            Console.ReadLine();
            return new MenuAdminController();
        }
    }
}
