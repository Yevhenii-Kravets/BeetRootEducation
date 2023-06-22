using Domain;

namespace Controllers
{
    internal class VotingController : IController
    {
        private IRepository repository;
        public VotingController()
        {
            repository = Factory.GetRepository();
        }
        public IController ExecuteAction()
        {
            var channel = repository.GetChannel();
            var user = channel.GetUserFromChannel();

            Console.WriteLine($"User name: {user.ToString()}");
            Console.WriteLine("Enter the voting ID:");
            var stringID = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(stringID))
            {
                Console.WriteLine("ID is empty");
                Console.ReadLine();
                return new MenuController();
            }
            else
            {
                bool isFound = false;
                foreach (var voting in channel.GetVotingsFromChannel())
                {
                    if (stringID == voting.GetID())
                    {
                        isFound = true;
                        Console.WriteLine($"\n{voting.ToString()}");

                        var l = 1;
                        foreach (var item in voting.GetChoices())
                            Console.WriteLine($"  {l++}. {item.ToString()}");

                        Console.WriteLine("Enter the choice index: ");
                        int index = 0;
                        bool indexIsTrue = int.TryParse(Console.ReadLine(), out index);

                        if (indexIsTrue)
                        {
                            var voteCast = voting.Vote(index, user);
                            if (!voteCast)
                            {
                                Console.WriteLine("unvoted");
                                return new MenuController();
                            }
                            else
                            {
                                Console.WriteLine($"{user.ToString()} is voted");
                                Console.ReadLine();
                                Factory.SaveRepository(channel);
                                return new MenuController();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                            Console.ReadLine();
                            return new MenuController();
                        }
                    }

                    if (!isFound)
                    {
                        Console.WriteLine("ID not found");
                        Console.ReadLine();
                        return new MenuController();
                    }
                }
            }
            return new MenuController();
        }
    }
}