using System.Drawing;

namespace Game
{
    public sealed class Snake
    {
        private static Snake? _snake;
        private List<Cell> Body = new List<Cell>()
        {
            new Cell(CellType.Head, new System.Drawing.Point(2, 1)),
            new Cell(CellType.Body, new System.Drawing.Point(2, 0))
        };

        private Snake() { }

        public static Snake GetSnake()
        {
            if (_snake == null)
                _snake = new Snake();
            return _snake;
        }

        public void AppendCellBody(int X, int Y)
        {
            Body.Add(new Cell(CellType.Body, new System.Drawing.Point(X, Y)));
        }

        public void OldRun(Destination destination, Cell[,] grid)
        {
            int minX = 0;
            int maxX = grid.GetLength(1) - 1;
            int minY = 0;
            int maxY = grid.GetLength(0) - 1;
            int index = Body.Count - 1;
            var food = Food.GetFood(grid);

            switch (destination)
            {
                case Destination.Up:
                    for (int i = 0; i < index + 1; i++)
                    {
                        if (i != index) // body
                        {
                            if (Body[index].GetCellType() == CellType.FullBody)
                            {
                                Body[index].UpdateCellType(CellType.Body);
                                Body.Add(new Cell(CellType.Body, new Point(Body[index].GetPosition().X,
                                                                           Body[index].GetPosition().Y)));
                            }
                            if (Body[index - 1].GetCellType() == CellType.FullBody)
                            {
                                Body[index].UpdateCellType(CellType.FullBody);
                                Body[index - 1].UpdateCellType(CellType.Body);
                            }
                            Body[index].UpdatePoint(
                                Body[index - 1].GetPosition().X,
                                Body[index - 1].GetPosition().Y);

                        }
                        else // head
                        {
                            if (Body[index - 1].GetPosition().Y - 1 == minY) // UP
                            {
                                Body[index - 1].UpdatePoint(
                                            Body[index - 1].GetPosition().X,
                                            Body[index - 1].GetPosition().Y - 1 + maxY - 1);
                            }
                            else if (new Point(Body[index - 1].GetPosition().X, // FOOD
                                               Body[index - 1].GetPosition().Y - 1) == food.GetPosition())
                            {
                                Body[index - 1].UpdatePoint(
                                    Body[index - 1].GetPosition().X,
                                    Body[index - 1].GetPosition().Y - 1);
                                Body[1].UpdateCellType(CellType.FullBody);
                                Food.RemoveFood();
                            }
                            else // default run
                            {
                                Body[index - 1].UpdatePoint(
                                    Body[index - 1].GetPosition().X,
                                    Body[index - 1].GetPosition().Y - 1);
                            }

                        }
                    }
                    break;

                case Destination.Down:
                    for (int i = 0; i < index + 1; i++)
                    {
                        if (i != index)
                        {
                            if (Body[index].GetCellType() == CellType.FullBody)
                            {
                                Body[index].UpdateCellType(CellType.Body);
                                Body.Add(new Cell(CellType.Body, new Point(Body[index].GetPosition().X,
                                                                           Body[index].GetPosition().Y)));
                            }
                            if (Body[index - 1].GetCellType() == CellType.FullBody)
                            {
                                Body[index].UpdateCellType(CellType.FullBody);
                                Body[index - 1].UpdateCellType(CellType.Body);
                            }
                            Body[index].UpdatePoint(
                                Body[index - 1].GetPosition().X,
                                Body[index - 1].GetPosition().Y);
                        }
                        else
                        {
                            if (Body[index - 1].GetPosition().Y + 1 == maxY) // DOWN
                            {
                                Body[index - 1].UpdatePoint(
                                    Body[index - 1].GetPosition().X,
                                    Body[index - 1].GetPosition().Y + 1 - maxY + 1);
                            }
                            else if (new Point(Body[index - 1].GetPosition().X, // FOOD
                                               Body[index - 1].GetPosition().Y + 1) == food.GetPosition())
                            {
                                Body[index - 1].UpdatePoint(
                                    Body[index - 1].GetPosition().X,
                                    Body[index - 1].GetPosition().Y + 1);
                                Body[1].UpdateCellType(CellType.FullBody);
                                Food.RemoveFood();
                            }
                            else // default run
                            {
                                Body[index - 1].UpdatePoint(
                                    Body[index - 1].GetPosition().X,
                                    Body[index - 1].GetPosition().Y + 1);
                            }
                        }
                    }
                    break;

                case Destination.Left:
                    for (int i = 0; i < index + 1; i++)
                    {
                        if (i != index)
                        {
                            if (Body[index].GetCellType() == CellType.FullBody)
                            {
                                Body[index].UpdateCellType(CellType.Body);
                                Body.Add(new Cell(CellType.Body, new Point(Body[index].GetPosition().X,
                                                                           Body[index].GetPosition().Y)));
                            }
                            if (Body[index - 1].GetCellType() == CellType.FullBody)
                            {
                                Body[index].UpdateCellType(CellType.FullBody);
                                Body[index - 1].UpdateCellType(CellType.Body);
                            }
                            Body[index].UpdatePoint(
                                Body[index - 1].GetPosition().X,
                                Body[index - 1].GetPosition().Y);
                        }
                        else
                        {
                            if (Body[index - 1].GetPosition().X - 1 == minX) // LEFT
                            {
                                Body[index - 1].UpdatePoint(
                                    Body[index - 1].GetPosition().X - 1 + maxX - 1,
                                    Body[index - 1].GetPosition().Y);
                            }
                            else if (new Point(Body[index - 1].GetPosition().X - 1, // FOOD
                                               Body[index - 1].GetPosition().Y) == food.GetPosition())
                            {
                                Body[index - 1].UpdatePoint(
                                    Body[index - 1].GetPosition().X - 1,
                                    Body[index - 1].GetPosition().Y);
                                Body[1].UpdateCellType(CellType.FullBody);
                                Food.RemoveFood();
                            }
                            else // default run
                            {
                                Body[index - 1].UpdatePoint(
                                    Body[index - 1].GetPosition().X - 1,
                                    Body[index - 1].GetPosition().Y);
                            }
                        }
                    }
                    break;

                case Destination.Right:
                    for (int i = 0; i < index + 1; i++)
                    {
                        if (i != index)
                        {
                            if (Body[index].GetCellType() == CellType.FullBody)
                            {
                                Body[index].UpdateCellType(CellType.Body);
                                Body.Add(new Cell(CellType.Body, new Point(Body[index].GetPosition().X,
                                                                           Body[index].GetPosition().Y)));
                            }
                            if (Body[index - 1].GetCellType() == CellType.FullBody)
                            {
                                Body[index].UpdateCellType(CellType.FullBody);
                                Body[index - 1].UpdateCellType(CellType.Body);
                            }
                            Body[index].UpdatePoint(
                                Body[index - 1].GetPosition().X,
                                Body[index - 1].GetPosition().Y);
                        }
                        else
                        {
                            if (Body[index - 1].GetPosition().X + 1 == maxX) // RIGHT
                            {
                                Body[index - 1].UpdatePoint(
                                    Body[index - 1].GetPosition().X + 1 - maxX + 1,
                                    Body[index - 1].GetPosition().Y);
                            }
                            else if (new Point(Body[index - 1].GetPosition().X + 1, // FOOD
                                               Body[index - 1].GetPosition().Y) == food.GetPosition())
                            {
                                Body[index - 1].UpdatePoint(
                                    Body[index - 1].GetPosition().X + 1,
                                    Body[index - 1].GetPosition().Y);
                                Body[1].UpdateCellType(CellType.FullBody);
                                Food.RemoveFood();
                            }
                            else // default run
                            {
                                Body[index - 1].UpdatePoint(
                                    Body[index - 1].GetPosition().X + 1,
                                    Body[index - 1].GetPosition().Y);
                            }
                        }
                    }
                    break;
            }
        }

        public void Run(Destination destination, Cell[,] grid)
        {
            int minX = 0;
            int maxX = grid.GetLength(1) - 1;
            int minY = 0;
            int maxY = grid.GetLength(0) - 1;
            int count = Body.Count - 1;
            var food = Food.GetFood(grid);

            for (int i = 0; i < Body.Count; i++)
            {
                if (i != count) // body
                {
                    if (Body[count - i].GetCellType() == CellType.FullBody)
                    {
                        Body[count - i].UpdateCellType(CellType.Body);
                        Body.Add(new Cell(CellType.Body, new Point(Body[count - i].GetPosition().X,
                                                                   Body[count - i].GetPosition().Y)));
                    }

                    if (Body[count - i - 1].GetCellType() == CellType.FullBody)
                    {
                        Body[count - i].UpdateCellType(CellType.FullBody);
                        Body[count - i - 1].UpdateCellType(CellType.Body);
                    }
                    Body[count - i].UpdatePoint(
                        Body[count - i - 1].GetPosition().X,
                        Body[count - i - 1].GetPosition().Y);
                }
                else
                    break;
            }

            switch (destination)
            {
                case Destination.Up:

                    if (Body[0].GetPosition().Y - 1 == minY) // UP
                    {
                        Body[0].UpdatePoint(
                                    Body[0].GetPosition().X,
                                    Body[0].GetPosition().Y - 1 + maxY - 1);
                        if (new Point(Body[0].GetPosition().X, // FOOD
                                       Body[0].GetPosition().Y) == food.GetPosition())
                        {
                            Body[1].UpdateCellType(CellType.FullBody);
                            Food.RemoveFood();
                        }
                    }
                    else if (new Point(Body[0].GetPosition().X, // FOOD
                                       Body[0].GetPosition().Y - 1) == food.GetPosition())
                    {
                        Body[0].UpdatePoint(
                            Body[0].GetPosition().X,
                            Body[0].GetPosition().Y - 1);
                        Body[1].UpdateCellType(CellType.FullBody);
                        Food.RemoveFood();
                    }
                    else // default run
                    {
                        Body[0].UpdatePoint(
                            Body[0].GetPosition().X,
                            Body[0].GetPosition().Y - 1);
                    }

                    break;

                case Destination.Down:
                    if (Body[0].GetPosition().Y + 1 == maxY) // DOWN
                    {
                        Body[0].UpdatePoint(
                            Body[0].GetPosition().X,
                            Body[0].GetPosition().Y + 1 - maxY + 1);
                        if (new Point(Body[0].GetPosition().X, // FOOD
                                      Body[0].GetPosition().Y) == food.GetPosition())
                        {
                            Body[1].UpdateCellType(CellType.FullBody);
                            Food.RemoveFood();
                        }
                    }
                    else if (new Point(Body[0].GetPosition().X, // FOOD
                                       Body[0].GetPosition().Y + 1) == food.GetPosition())
                    {
                        Body[0].UpdatePoint(
                            Body[0].GetPosition().X,
                            Body[0].GetPosition().Y + 1);
                        Body[1].UpdateCellType(CellType.FullBody);
                        Food.RemoveFood();
                    }
                    else // default run
                    {
                        Body[0].UpdatePoint(
                            Body[0].GetPosition().X,
                            Body[0].GetPosition().Y + 1);
                    }
                    break;

                case Destination.Left:
                    if (Body[0].GetPosition().X - 1 == minX) // LEFT
                    {
                        Body[0].UpdatePoint(
                            Body[0].GetPosition().X - 1 + maxX - 1,
                            Body[0].GetPosition().Y);
                        if (new Point(Body[0].GetPosition().X, // FOOD
                                      Body[0].GetPosition().Y) == food.GetPosition())
                        {
                            Body[1].UpdateCellType(CellType.FullBody);
                            Food.RemoveFood();
                        }
                    }
                    else if (new Point(Body[0].GetPosition().X - 1, // FOOD
                                       Body[0].GetPosition().Y) == food.GetPosition())
                    {
                        Body[0].UpdatePoint(
                            Body[0].GetPosition().X - 1,
                            Body[0].GetPosition().Y);
                        Body[1].UpdateCellType(CellType.FullBody);
                        Food.RemoveFood();
                    }
                    else // default run
                    {
                        Body[0].UpdatePoint(
                            Body[0].GetPosition().X - 1,
                            Body[0].GetPosition().Y);
                    }
                    break;

                case Destination.Right:
                    if (Body[0].GetPosition().X + 1 == maxX) // RIGHT
                    {
                        Body[0].UpdatePoint(
                            Body[0].GetPosition().X + 1 - maxX + 1,
                            Body[0].GetPosition().Y);
                        if (new Point(Body[0].GetPosition().X, // FOOD
                                      Body[0].GetPosition().Y) == food.GetPosition())
                        {
                            Body[1].UpdateCellType(CellType.FullBody);
                            Food.RemoveFood();
                        }
                    }
                    else if (new Point(Body[0].GetPosition().X + 1, // FOOD
                                       Body[0].GetPosition().Y) == food.GetPosition())
                    {
                        Body[0].UpdatePoint(
                            Body[0].GetPosition().X + 1,
                            Body[0].GetPosition().Y);
                        Body[1].UpdateCellType(CellType.FullBody);
                        Food.RemoveFood();
                    }
                    else // default run
                    {
                        Body[0].UpdatePoint(
                            Body[0].GetPosition().X + 1,
                            Body[0].GetPosition().Y);
                    }
                    break;
            }
        }

        public List<Cell> GetSnakeBody() => Body;
    }
}
