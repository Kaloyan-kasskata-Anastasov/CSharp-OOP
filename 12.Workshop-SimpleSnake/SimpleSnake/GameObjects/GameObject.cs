using SimpleSnake.Core;
using SimpleSnake.Core.Interfaces;

namespace SimpleSnake.GameObjects
{
internal class GameObject : Point, IDrawable
{
    public char DrawSymbol { get; }

    public GameObject(char drawSymbol)
        : base(0, 0)
    {
        DrawSymbol = drawSymbol;
    }

    public GameObject(char drawSymbol, int x, int y)
        : base(x, y)
    {
        DrawSymbol = drawSymbol;
    }

    public void Draw()
    {
        PlatformInteractions.Draw(this, DrawSymbol);
    }
}
}
