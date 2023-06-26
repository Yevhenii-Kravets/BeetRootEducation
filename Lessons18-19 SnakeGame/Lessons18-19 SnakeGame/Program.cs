using Game;
internal class Program
{
    private static void Main(string[] args)
    {
        SnakeGame snakeGame = SnakeGame.GetSnakeGame(60, 25);
        snakeGame.SetHeadSneak("O");
        snakeGame.SetBodySnake("o");
        snakeGame.SetFood("a");
        snakeGame.SetFullBodySnake("9");

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
                    }
                }
            }
        });
        
        while (true)
        {
            Thread.Sleep(10);
            Console.Clear();

            Console.WriteLine(snakeGame.Go());
        }
    }
}