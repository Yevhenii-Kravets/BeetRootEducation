using Scheme;

namespace Controllers
{
    public class RoomAddController : IController
    {
        public IController ExecuteAction()
        {
            Console.Clear();

            var calendar = Calendar.GetInstance();

            Console.WriteLine("\nEnter name:");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name is empty");
                Console.ReadLine();
                return new MenuAdminController();
            }

            foreach (var room in calendar.GetRooms())
                if (room.Name == name)
                {
                    Console.WriteLine("This room has been added");
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

            calendar.AddRoom(name, seats);
            Console.WriteLine("Room added");
            Console.ReadLine();
            return new MenuAdminController();
        }
    }
}
