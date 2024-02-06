using Scheme;

namespace Controllers
{
    public class RoomUpdateController : IController
    {
        public IController ExecuteAction()
        {
            Console.Clear();

            var calendar = Calendar.GetInstance();
            Room room = null;

            Console.Write("\nEnter the room name you want to update: ");
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

            Console.WriteLine("\nRoom:"
                + $"Name: {room.Name}"
                + $"Seats: {room.Seats}\n");

            Console.WriteLine("\nEnter name:");
            var newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Name is empty");
                Console.ReadLine();
                return new MenuAdminController();
            }


            Console.WriteLine("\nEnter the number of seats:");
            var seatsIsTrue = int.TryParse(Console.ReadLine(), out int seats);
            if (!seatsIsTrue)
            {
                Console.WriteLine("Incorrect format");
                Console.ReadLine();
                return new MenuAdminController();
            }

            calendar.RemoveRoom(room);
            calendar.AddRoom(name, seats);
            Console.WriteLine("Room update");
            Console.ReadLine();
            return new MenuAdminController();
        }
    }
}
