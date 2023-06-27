
using System.Drawing;

namespace Game
{
    public class Cell
    {
        private CellType CellType { get; set; }
        private Point Point { get; set; }

        public Cell(CellType CellType, Point Point)
        {
            this.CellType = CellType;
            this.Point = Point;
        }

        public void UpdatePoint(int X, int Y)
        {
            this.Point = new Point(X, Y);
        }
        public Point GetPosition() => Point;

        public void UpdateCellType(CellType cellType)
        {
            this.CellType = cellType;
        }
        public CellType GetCellType() => CellType;

    }
}
