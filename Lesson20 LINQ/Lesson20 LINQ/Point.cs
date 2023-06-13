public struct Point
{
    public double X;
    public double Y;
    public Point(double X, double Y)
    {
        this.X = X;
        this.Y = Y;
    }
}

public static class PointExtensions
{
    public static double Distance(this Point point1, Point point)
    {
        double deltaX = point1.X - point.X;
        double deltaY = point1.Y - point.Y;

        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
}