namespace Controllers
{
    public class StartMenuController : IController
    {
        public IController ExecuteAction()
        {
            Console.Clear();
            Console.WriteLine("You want to login as a:"
                          + "\n 1. User"
                          + "\n 2. Administrator"
                          + "\n 0. Exit");

            var keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.D0: return null;
                case ConsoleKey.D2: return new RegistrationMenuAdminController();
                case ConsoleKey.D1: return new MenuController();

                default: return new StartMenuController();
            }
        }
    }
}
