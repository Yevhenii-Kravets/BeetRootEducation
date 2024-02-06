using Scheme;

namespace Controllers
{
    public class MeetingUpdateController : IController
    {
        public IController ExecuteAction()
        {
            Console.Clear();

            var calendar = Calendar.GetInstance();
            Meeting meeting = null;

            Console.Write("\nEnter the meeting ID you want to edit: ");
            var guidIsTrue = Guid.TryParse(Console.ReadLine(), out var guid);
            if(!guidIsTrue)
            {
                Console.WriteLine("Incorrect ID format");
                Console.ReadLine();
                return new MenuAdminController();
            }
            else
                foreach(var meet in calendar.GetMeetings())
                    if(meet.ID == guid)
                        meeting = meet;

            if(meeting == null)
            {
                Console.WriteLine("Meeting not found");
                Console.ReadLine();
                return new MenuAdminController();
            }

            Console.WriteLine("Meeting:"
                + $"\nID: {meeting.ID}"
                + $"\nName: {meeting.Name}"
                + $"\nStart time: {meeting.StartTime}"
                + $"\nDuration: {meeting.Duration}"
                );

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
            if (int.TryParse(Console.ReadLine(), out int minutes))
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

            foreach (var meet in calendar.GetMeetings())
                if (room == meet.Room.Name && guid != meet.ID &&
                    date < meet.StartTime + meet.Duration && date + duration > meet.StartTime)
                {
                    Console.WriteLine("The room is busy at this time");
                    Console.ReadLine();
                    return new MenuAdminController();
                }

            calendar.RemoveMeeting(meeting);
            calendar.AddMeeting(guid, name, room, duration, date);
            Console.WriteLine("Meeting update");
            Console.ReadLine();
            return new MenuAdminController();
        }
    }
}
