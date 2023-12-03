using System.Collections.Generic;
using System.Linq;
using SimpleSnake.Core.Interfaces;

namespace SimpleSnake.GameObjects
{
internal class Snake : ICollidable
{
    private const char SnakeSymbol = '\u25CF';
    private const char EmptySpace = ' ';

    private readonly Queue<GameObject> snakeElements;

    public Snake()
    {
        snakeElements = new Queue<GameObject>();
        GenerateSnakeElements();
    }

    public GameObject Head => snakeElements.Last();

    public Point GetNextPoint(Point direction, Point snakeHead)
    {
        return new Point(
            snakeHead.X + direction.X,
            snakeHead.Y + direction.Y);
    }

    public void Grow(Point direction, Point currentSnakeHead, int growPoints)
    {
        Point nextPoint = currentSnakeHead;
        for (int i = 0; i < growPoints; i++)
        {
            GameObject newElement = new GameObject(SnakeSymbol, nextPoint.X, nextPoint.Y);
            snakeElements.Enqueue(newElement);
            nextPoint = GetNextPoint(direction, currentSnakeHead);
        }
    }

    private void GenerateSnakeElements()
    {
        for (int y = 0; y <= 6; y++)
        {
            snakeElements.Enqueue(new GameObject(SnakeSymbol, 2, y));
        }
    }

    public void Move(GameObject snakeHead)
    {
        snakeElements.Enqueue(snakeHead);
        snakeHead.Draw();

        GameObject snakeTail = snakeElements.Dequeue();
        snakeTail = new GameObject(EmptySpace, snakeTail.X, snakeTail.Y);
        snakeTail.Draw();
    }

    public bool IsCollidesWith(Point point)
    {
        return snakeElements
            .Any(snakeObject => snakeObject.X == point.X && snakeObject.Y == point.Y);
    }
}
}
