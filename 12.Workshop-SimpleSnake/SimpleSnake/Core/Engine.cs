using System;
using System.Threading;
using SimpleSnake.Core.Interfaces;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Foods;

namespace SimpleSnake.Core
{
internal class Engine : IEngine
{
    public static GameState state;
    
    private static Wall fieldBoundaries;
    private Snake snake;
    private Food foodReference;
    private Direction lastDirection;
    private double sleepTime;
    private Point[] pointsOfDirection;
    private Random random;
    private readonly Food[] foods;

    public Engine(Wall boundaries, Snake snake)
    {
        random = new Random();
        sleepTime = 100;

        pointsOfDirection = new Point[4];
        fieldBoundaries = boundaries;
        this.snake = snake;
        foods = new Food[]
        {
            new FoodHash(),
            new FoodDollar(),
            new FoodAsterisk()
        };
    }

    public void Run()
    {
        CreateDirections();
        PlaceFoodOnField();

        state = GameState.Running;
        while (state != GameState.Over)
        {
            if (Console.KeyAvailable)
            {
                lastDirection = GetDirection();
            }

            state = UpdateSnake(pointsOfDirection[(int)lastDirection]);

            if (state == GameState.Over)
            {
                PlatformInteractions.GameOver(fieldBoundaries);
            }
            else
            {
                sleepTime -= 0.01;
                Thread.Sleep((int)sleepTime);
            }
        }
    }

    private GameState UpdateSnake(Point direction)
    {
        GameObject currentSnakeHead = snake.Head;
        Point nextHeadPoint = GetNextPoint(direction, currentSnakeHead);

        if (snake.IsCollidesWith(nextHeadPoint))
        {
            return GameState.Over;
        }

        GameObject snakeNewHead = new GameObject(currentSnakeHead.DrawSymbol, nextHeadPoint.X, nextHeadPoint.Y);

        if (fieldBoundaries.IsCollidesWith(snakeNewHead))
        {
            return GameState.Over;
        }

        if (foodReference.CollidesWith(currentSnakeHead))
        {
            snake.Grow(direction, currentSnakeHead, foodReference.FoodPoints);
            PlaceFoodOnField();
        }

        snake.Move(snakeNewHead);

        return GameState.Running;
    }

    public Point GetNextPoint(Point direction, Point snakeHead)
    {
        return new Point(
            snakeHead.X + direction.X,
            snakeHead.Y + direction.Y);
    }

    public void CreateDirections()
    {
        pointsOfDirection[0] = new Point(1, 0);
        pointsOfDirection[1] = new Point(-1, 0);
        pointsOfDirection[2] = new Point(0, 1);
        pointsOfDirection[3] = new Point(0, -1);
    }

    public void PlaceFoodOnField()
    {
        int randomFoodIndex = random.Next(0, foods.Length - 1);
        foodReference = foods[randomFoodIndex];

        do
        {
            foodReference.X = random.Next(2, fieldBoundaries.X - 2);
            foodReference.Y = random.Next(2, fieldBoundaries.Y - 2);
        } while (snake.IsCollidesWith(foodReference));

        foodReference.Draw();
    }

    public Direction GetDirection()
    {
        return PlatformInteractions.GetInput(lastDirection);
    }
}

internal enum GameState
{
    Idle,
    Start,
    Running,
    Over
}
}
