using Domain;
using Items;

namespace Controllers
{
    public class MenuController : IController
    {

        private IRepository repository;
        public MenuController()
        {
            repository = Factory.GetRepository();
        }

        public IController ExecuteAction()
        {
            if(repository.GetChannel().ToString()  == null)
            {
                Console.WriteLine("Enter name channel:");
                var nameChannel = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nameChannel))
                {
                    Channel channel = new Channel();
                    channel.SetName(nameChannel);
                    Factory.SaveRepository(channel);
                    new MenuController();
                }
            }

            Console.Clear();
            Menu();

            var KeyInfo = Console.ReadKey();
            switch (KeyInfo.Key)
            {
                case ConsoleKey.D0:
                    return null;

                case ConsoleKey.D1:
                    Console.WriteLine();
                    return new ShowVotingsController();

                case ConsoleKey.D2:
                    Console.WriteLine();
                    return new AddVotingController();

                case ConsoleKey.D3:
                    Console.WriteLine();
                    return new VotingController();

                    case ConsoleKey.D4:
                    Console.WriteLine();
                    return new UserController();

                default: return new MenuController();
            }
        }

        void Menu()
        {
            Console.WriteLine($"Name channel {repository.GetChannel().ToString()}: "
                          + "\n1. Show votings"
                          + "\n2. Add voting"
                          + "\n3. Vote"
                          + "\n4. Add user"
                          + "\n0. Exit program");
        }

    }
}
