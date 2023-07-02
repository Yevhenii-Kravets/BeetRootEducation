using Scheme;

namespace Controllers
{
    public class MeetingAddController : IController
    {
        public IController ExecuteAction()
        {
            Console.Clear();

            var calendar = Calendar.GetInstance();

            if(calendar.GetRooms().Count <= 0)
            {
                Console.WriteLine("First add the room");
                Console.ReadLine();
                return new MenuAdminController();
            }

            var guid = Guid.NewGuid();
            Console.WriteLine($"Add meeting {guid}:");

            Console.WriteLine("\nEnter name:");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name is empty");
                Console.ReadLine();
                return new MenuAdminController();
            }

            Console.WriteLine("\nRooms");
            foreach (var item in calendar.GetRooms())
                Console.WriteLine(item.Name);
            Console.WriteLine();

            Console.WriteLine("\nEnter room name:");
            var room = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Room is empty");
                Console.ReadLine();
                return new MenuAdminController();
            }
            else
            {
                bool isFound = false;
                foreach (var item in calendar.GetRooms())
                    if (item.Name == room)
                    {
                        isFound = true;
                        break;
                    }

                if (!isFound)
                {
                    Console.WriteLine("There is no such room");
                    Console.ReadLine();
                    return new MenuAdminController();
                }
            }

            Console.WriteLine("\nEnter duration in minutes:");
            TimeSpan duration;
            if(int.TryParse(Console.ReadLine(), out int minutes))
                duration = new TimeSpan(0, minutes, 0);
            else
            {
                Console.WriteLine("Incorrect format of duration");
                Console.ReadLine();
                return new MenuAdminController();
            }

            Console.WriteLine("\nEnter start time:");
            DateTime date;
            if (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Incorrect date or time format");
                Console.ReadLine();
                return new MenuAdminController();
            }

            foreach (var meeting in calendar.GetMeetings())
                if (room == meeting.Room.Name &&  date < meeting.StartTime + meeting.Duration && date + duration > meeting.StartTime) 
                {
                    Console.WriteLine("The room is busy at this time");
                    Console.ReadLine();
                    return new MenuAdminController();
                }

            calendar.AddMeeting(guid, name, room, duration, date);
            Console.WriteLine("Meeting added");
            Console.ReadLine();
            return new MenuAdminController();
        }
    }
}
