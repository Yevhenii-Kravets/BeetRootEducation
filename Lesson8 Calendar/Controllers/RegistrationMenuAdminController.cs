using Scheme;

namespace Controllers
{
    public class RegistrationMenuAdminController : IController
    {
        int MaxLenLogin = 20;
        int MaxLenPassword = 20;

        public IController ExecuteAction()
        {
            Console.Clear();

            Console.WriteLine("Enter the admin login:");
            var login = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(login) && login.Length > MaxLenLogin)
            {
                Console.WriteLine("Login empty or too long");
                Console.ReadLine();
                return new RegistrationMenuAdminController();
            }

            Console.WriteLine("Enter the admin password:");
            var password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password) && password.Length > MaxLenPassword)
            {
                Console.WriteLine("Password empty or too long");
                Console.ReadLine();
                return new RegistrationMenuAdminController();
            }

            if(Admin.GetInstance(login, password).UserIsAdmin())
                return new MenuAdminController();

            Console.WriteLine("No access");
            Console.ReadLine();

            return new StartMenuController();
        }
    }
}
