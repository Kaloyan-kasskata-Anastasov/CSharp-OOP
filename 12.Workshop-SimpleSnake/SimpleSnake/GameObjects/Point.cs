using SimpleSnake.Core.Interfaces;

namespace SimpleSnake.GameObjects
{
internal class Point : ICollidable
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }

    public int Y { get; set; }

    public virtual bool IsCollidesWith(Point point)
    {
        return point.X == 0 ||
               point.Y == 0 ||
               point.X == X - 1 ||
               point.Y == Y;
    }
}
}
