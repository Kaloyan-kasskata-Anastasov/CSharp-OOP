using SimpleSnake.GameObjects;

namespace SimpleSnake.Core.Interfaces;

internal interface ICollidable
{
    bool IsCollidesWith(Point point);
}
