using Domain;
using Items;

namespace Controllers
{
    public class AddVotingController : IController
    {
        private IRepository repository;

        public AddVotingController()
        {
            repository = Factory.GetRepository();
        }
        public IController ExecuteAction()
        {
            Console.Clear();

            Console.WriteLine("Add voting:");
            Voting voting = null;

            Console.WriteLine("\nEnther name: ");
            var name = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(name))
            {
                voting = new Voting(name);
            }
            else
            {
                Console.WriteLine("Name is empty");
                return new MenuController();
            }

            do
            {
                Console.WriteLine("Enther title choice: ");
                var choice = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(choice))
                {
                    voting.AddChoice(choice);
                }
                else
                {
                    Console.WriteLine("\nEmpty title choice");
                }

                Console.WriteLine("1. Add choice \n0.Exit");
                var keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        continue;

                    case ConsoleKey.D0:
                        var channel = repository.GetChannel();
                        if (voting.GetChoices().Count > 0) {
                            channel.AddVotingToChannel(voting);
                            Factory.SaveRepository(channel);
                        }
                        return new MenuController();

                    default: return new MenuController();
                }

            } while (true);

            
        }
    }
}
