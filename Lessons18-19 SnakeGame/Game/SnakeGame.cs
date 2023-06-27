using System.Drawing;
using Logs;

namespace Game
{
    public enum CellType
    {
        Head,
        Body,
        FullBody,
        EmptyCell,
        Food,
        Barrier
    }
    public enum Destination
    {
        Up,
        Down,
        Left,
        Right
    }

    public sealed class SnakeGame
    {
        private static SnakeGame _instance;

        private char HeadSnakeSymbol { get; set; } = 'G';
        private char BodySnakeSymbol { get; set; } = 'o';
        private char FullBodySnakeSymbol { get; set; } = 'O';
        private char FoodSymbol { get; set; } = 'Q';
        private char EmptyCellSymbol { get; set; } = ' ';
        private char BarierSymbol { get; set; } = '█';

        private Destination Destination { get; set; } = Destination.Right;
        private Cell[,] Grid { get; init; }

        private SnakeGame(int X, int Y)
        {
            Grid = new Cell[Y, X];
            for (int i = 0; i < Grid.GetLength(0); i++)
                for (int j = 0; j < Grid.GetLength(1); j++)
                    if (i == 0 ||
                        i == Grid.GetLength(0) - 1 ||
                        j == 0 ||
                        j == Grid.GetLength(1) - 1)
                        Grid[i, j] = new Cell(CellType.Barrier, new Point(i, j));
                    else
                        Grid[i, j] = new Cell(CellType.EmptyCell, new Point(i, j));
        }

        public static SnakeGame GetSnakeGame(int X, int Y)
        {
            if(_instance == null)
                _instance = new SnakeGame(X, Y);
            return _instance;
        }
        public int EndGame()
        {
            _instance = null;
            int count = Snake.GetSnake().GetSnakeBody().Count;
            int score = count > 2 ? (count - 2) * 100 : 0;
            Snake.GetSnake().RemoveSnake();

            return score;
        }

        public string Go()
        {
            var grid = SetItemsToGrid();
            var resultRun = Snake.GetSnake().Run(Destination, grid);
            if (!resultRun)
            {
                int score = EndGame();
                Log.WriteLog(score + "");
                return "Game Over";
            }

            string result = "";

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                if (i != 0)
                    result += "\n";
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    switch (grid[i, j].GetCellType())
                    {
                        case CellType.EmptyCell: result += EmptyCellSymbol; break;
                        case CellType.Head: result += HeadSnakeSymbol; break;
                        case CellType.Body: result += BodySnakeSymbol; break;
                        case CellType.Barrier: result += BarierSymbol; break;
                        case CellType.Food: result += FoodSymbol; break;
                        case CellType.FullBody: result += FullBodySnakeSymbol; break;
                    }
                }
            }
            
            return result;
        }
        public Cell[,] SetItemsToGrid()
        {
            Cell[,] newGrid = new Cell[Grid.GetLength(0), Grid.GetLength(1)];
            Array.Copy(Grid, newGrid, Grid.Length);

            foreach (var bodyCell in Snake.GetSnake().GetSnakeBody())
                newGrid[bodyCell.GetPosition().Y, bodyCell.GetPosition().X] = bodyCell;

            var food = Food.GetFood(newGrid);
            newGrid[food.GetPosition().Y, food.GetPosition().X] = food;

            return newGrid;
        }

        public void SetHeadSneak(char symbol)
        {
            this.HeadSnakeSymbol = symbol;
        }
        public void SetBodySnake(char symbol)
        {
            this.BodySnakeSymbol = symbol;
        }
        public void SetFullBodySnake(char symbol)
        {
            this.FullBodySnakeSymbol = symbol;
        }
        public void SetFood(char symbol)
        {
            this.FoodSymbol = symbol;
        }
        public void SetEmptyCell(char symbol)

        {
            this.EmptyCellSymbol = symbol;
        }

        public void RunUp()
        {
            if (Destination != Destination.Down)
                Destination = Destination.Up;
        }
        public void RunDown()
        {
            if (Destination != Destination.Up)
                Destination = Destination.Down;
        }
        public void RunLeft()
        {
            if (Destination != Destination.Right)
                Destination = Destination.Left;
        }
        public void RunRight()
        {
            if (Destination != Destination.Left)
                Destination = Destination.Right;
        }

    }
}