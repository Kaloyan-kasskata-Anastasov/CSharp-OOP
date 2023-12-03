// System namespace

namespace SimpleSnake.GameObjects
{
internal class Wall : GameObject
{
    private const char WallSymbol = '\u25A0';

    public Wall(int x, int y)
        : base(WallSymbol, x, y)
    {
        InitializeWallBorders();
    }

    private void InitializeWallBorders()
    {
        DrawHorizontalLine(0);
        DrawHorizontalLine(Y);
        DrawVerticalLine(0);
        DrawVerticalLine(X - 1);
    }

    private void DrawHorizontalLine(int column)
    {
        for (int row = 0; row < X; row++)
        {
            GameObject drawPoint = new GameObject(DrawSymbol, row, column);
            drawPoint.Draw();
        }
    }

    private void DrawVerticalLine(int row)
    {
        for (int column = 0; column < Y; column++)
        {
            GameObject drawPoint = new GameObject(DrawSymbol, row, column);
            drawPoint.Draw();
        }
    }

    public override bool IsCollidesWith(Point point)
    {
        return point.Y == 0 ||
               point.X == 0 ||
               point.X == X - 1 ||
               point.Y == Y;
    }
}
}
