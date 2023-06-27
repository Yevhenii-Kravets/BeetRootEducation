using Game;

namespace Controllers
{
    public class GameController : IController
    {
        public IController ExecuteAction()
        {
            SnakeGame snakeGame = SnakeGame.GetSnakeGame(60, 25);
            snakeGame.SetBodySnake('+');
            snakeGame.SetHeadSneak('#');

            Task inputTask = Task.Run(() =>
            {
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow: case ConsoleKey.W: snakeGame.RunUp(); break;

                            case ConsoleKey.DownArrow: case ConsoleKey.S: snakeGame.RunDown(); break;

                            case ConsoleKey.LeftArrow: case ConsoleKey.A: snakeGame.RunLeft(); break;

                            case ConsoleKey.RightArrow: case ConsoleKey.D: snakeGame.RunRight(); break;

                            case ConsoleKey.Escape: case ConsoleKey.Enter: case ConsoleKey.Spacebar:
                                snakeGame.EndGame();
                                return new MenuController();
                        }
                    }
                }
            });

            while (true)
            {
                Thread.Sleep(10);
                Console.Clear();

                string res = snakeGame.Go();
                Console.WriteLine(res);

                if (res == "Game Over")
                {
                    Console.ReadLine();
                    return new MenuController();
                }
            }

        }
    }
}
