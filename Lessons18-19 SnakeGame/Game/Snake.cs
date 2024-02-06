using System.Drawing;

namespace Game
{
    public sealed class Snake
    {
        private static Snake? _snake;
        private List<Cell> Body { get; set; }


        private Snake()
        {
            Body = new List<Cell>()
            {
                new Cell(CellType.Head, new Point(2, 1)),
                new Cell(CellType.Body, new Point(1, 1))
            };
        }

        public static Snake GetSnake()
        {
            if (_snake == null)
                _snake = new Snake();
            return _snake;
        }
        public void RemoveSnake()
        {
            _snake = null;
        }
        public bool Run(Destination destination, Cell[,] grid)
        {
            int minX = 0;
            int maxX = grid.GetLength(1) - 1;
            int minY = 0;
            int maxY = grid.GetLength(0) - 1;
            var food = Food.GetFood(grid);

            RunBody();
            switch (destination)
            {
                case Destination.Up:
                    return RunHead(grid, food, new Point(0, -1), minX, maxY);

                case Destination.Down:
                    return RunHead(grid, food, new Point(0, 1), minX, -maxY);

                case Destination.Left:
                    return RunHead(grid, food, new Point(-1, 0), maxX, minY);

                case Destination.Right:
                    return RunHead(grid, food, new Point(1, 0), -maxX, minY);

                default: return true;
            }
        }
        public List<Cell> GetSnakeBody() => Body;

        private void RunBody()
        {
            int count = Body.Count - 1; // получить длинну тела без головы

            for (int i = 0; i < count; i++)
            {
                // если текущая ячейка тела (последняя) сытая - добавить новую
                if (Body[count - i].GetCellType() == CellType.FullBody)  
                {
                    Body[count - i].UpdateCellType(CellType.Body);
                    Body.Add(new Cell(CellType.Body, new Point(Body[count - i].GetPosition().X,
                                                               Body[count - i].GetPosition().Y)));
                }

                // если следующая ячейка тела сытая - добавить новую
                if (Body[count - i - 1].GetCellType() == CellType.FullBody)
                {
                    Body[count - i].UpdateCellType(CellType.FullBody);
                    Body[count - i - 1].UpdateCellType(CellType.Body);
                }

                // передвинуть ячейку на координату вперед
                Body[count - i].UpdatePoint(
                    Body[count - i - 1].GetPosition().X,
                    Body[count - i - 1].GetPosition().Y);
            }
        }
        private bool RunHead(Cell[,] grid, Cell food, Point nextPoint, int boundaryСoordinateX, int boundaryСoordinateY)
        {
            // если следущая координата это край
            if (grid[Body[0].GetPosition().Y + nextPoint.Y,
                     Body[0].GetPosition().X + nextPoint.X].GetCellType() == CellType.Barrier)
            {
                // передвинуть голову за противоположную границу
                Body[0].UpdatePoint(
                            Body[0].GetPosition().X + boundaryСoordinateX + (nextPoint.X * 2),
                            Body[0].GetPosition().Y + boundaryСoordinateY + (nextPoint.Y * 2));

                // если за противоположной границей еда
                if (grid[Body[0].GetPosition().Y,
                         Body[0].GetPosition().X].GetCellType() == CellType.Food)
                {
                    // установить сытую ячейку на первую ячейку тела
                    Body[1].UpdateCellType(CellType.FullBody);
                    // удалить еду
                    Food.RemoveFood();
                }
            }
            // или если на следующей координате еда
            else if (grid[Body[0].GetPosition().Y + nextPoint.Y,
                          Body[0].GetPosition().X + nextPoint.X].GetCellType() == CellType.Food)
            {
                // передвинуть голову вперед
                Body[0].UpdatePoint(
                    Body[0].GetPosition().X + nextPoint.X,
                    Body[0].GetPosition().Y + nextPoint.Y);
                // установить сытую ячейку на первую ячейку тела
                Body[1].UpdateCellType(CellType.FullBody);
                // удалить еду
                Food.RemoveFood();
            }
            // если следующая координата - тело
            else if (grid[Body[0].GetPosition().Y + nextPoint.Y,
                          Body[0].GetPosition().X + nextPoint.X].GetCellType() == CellType.Body
                     || grid[Body[0].GetPosition().Y + nextPoint.Y,
                          Body[0].GetPosition().X + nextPoint.X].GetCellType() == CellType.FullBody)
            {
                return false;
            }
            // двигаться вперед
            else
            {
                // передвинуть голову вперед
                Body[0].UpdatePoint(
                    Body[0].GetPosition().X + nextPoint.X,
                    Body[0].GetPosition().Y + nextPoint.Y);
            }

            return true;
        }
    }
}
