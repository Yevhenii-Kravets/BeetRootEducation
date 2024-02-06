using Logs;

namespace Controllers
{
    public class ScoresController : IController
    {
        public IController ExecuteAction()
        {
            foreach (var log in Log.ReadLogs())
            {
                Console.WriteLine(log);
            }

            Console.ReadLine();
            return new MenuController();
        }
    }
}
