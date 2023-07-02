using Scheme;

namespace Controllers
{
    public class MeetingRemoveController : IController
    {
        public IController ExecuteAction()
        {
            Console.Clear();

            var calendar = Calendar.GetInstance();
            Meeting meeting = null;

            Console.Write("\nEnter the meeting ID you want to remove: ");
            var guidIsTrue = Guid.TryParse(Console.ReadLine(), out var guid);
            if (!guidIsTrue)
            {
                Console.WriteLine("Incorrect ID format");
                Console.ReadLine();
                return new MenuAdminController();
            }
            else
                foreach (var meet in calendar.GetMeetings())
                    if (meet.ID == guid)
                        meeting = meet;

            if (meeting == null)
            {
                Console.WriteLine("Meeting not found");
                Console.ReadLine();
                return new MenuAdminController();
            }

            calendar.RemoveMeeting(meeting);
            Console.WriteLine("Meeting remove");
            Console.ReadLine();
            return new MenuAdminController();
        }
    }
}
