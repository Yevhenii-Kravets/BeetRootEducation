using static System.Formats.Asn1.AsnWriter;

namespace Controllers
{
    public class MenuController : IController
    {
        public IController ExecuteAction()
        {
            Console.Clear();
            Menu();

            var KeyInfo = Console.ReadKey();
            switch (KeyInfo.Key)
            {
                case ConsoleKey.D0:
                    return null;

                case ConsoleKey.D1:
                    return new GameController();

                case ConsoleKey.D2:
                    return new ScoresController();

                default: return new MenuController();
            }
        }

        private void Menu()
        {
            Console.WriteLine("WELCOME TO SNAKE GAME"
                + "\n1. New game"
                + "\n2. Scores"
                + "\n0. Exit");
        }
    }
}