using Scheme;

namespace Controllers
{
    public class MeetingsShowController : IController
    {
        private IController? previousController;
        public MeetingsShowController(IController controller = null)
        {
            previousController = controller;
        }

        public IController ExecuteAction()
        {
            Console.Clear();
            Console.WriteLine("Meetings: ");

            var meetingsCount = Calendar.GetInstance().GetMeetings().Count;
            if (meetingsCount <= 0)
                Console.WriteLine("Meetings not found");
            else
                foreach (var meeting in Calendar.GetInstance().GetMeetings())
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
