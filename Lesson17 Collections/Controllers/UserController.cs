using Domain;
using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class UserController : IController
    {
        IRepository repository;
        public UserController() 
        { 
            repository = Factory.GetRepository();
        }

        public IController ExecuteAction()
        {
            var channel = repository.GetChannel();

            var firstNames = File.ReadAllLines("RandomNames.txt");
            var lastNames = File.ReadAllLines("RandomLastNames.txt");

            string name = firstNames[new Random().Next(0, firstNames.Length - 1)];
            string lastName = lastNames[new Random().Next(0, lastNames.Length - 1)];

            var user = new User($"{name} {lastName}");

            channel.AddUserToChannel(user);
            Factory.SaveRepository(channel);

            Console.WriteLine($"Add user {user.ToString()}");
            Console.ReadLine();

            return new MenuController();
        }

    }
}
