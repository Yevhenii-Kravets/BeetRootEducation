using Domain;
using Items;

namespace Controllers
{
    public class ShowVotingsController : IController
    {
        private IRepository repository;
        public ShowVotingsController() 
        {
            repository = Factory.GetRepository();
        }

        public IController ExecuteAction()
        {
            var channel = repository.GetChannel();

            ShowAllVotings(channel);

            return new MenuController();
        }

        private void ShowAllVotings(Channel Channel)
        {
            if (Channel.GetVotingsFromChannel().Count > 0)
            {
                var i = 1;
                foreach (var voting in Channel.GetVotingsFromChannel())
                {
                    Console.WriteLine($"\n{i} - {voting.ToString()}, {voting.GetID()}");
                    Console.WriteLine(" \\");
                    var l = 1;
                    foreach(var item in voting.GetChoices())
                        Console.WriteLine($"  {i}.{l++} - {item.ToString()}, votes: {item.GetCountVotes()}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Empty");
            }
            Console.ReadLine();
        }
    }
}
