using System.Drawing;

namespace Game
{
    public sealed class Food
    {
        private static Cell? _food;

        private Food() { }

        public static Cell GetFood(Cell[,] Grid)
        {
            if (_food == null)
            {
                int x, y;

                while (true) {
                    x = new Random().Next(1, Grid.GetLength(1));
                    y = new Random().Next(1, Grid.GetLength(0));
                    if (Grid[y, x].GetCellType() != CellType.EmptyCell)
                        continue;
                    break;
                }
                _food = new Cell(CellType.Food, new Point(x, y));
            }
            return _food;
        }
        public static void RemoveFood()
        {
            _food = null;
        }
    }
}
