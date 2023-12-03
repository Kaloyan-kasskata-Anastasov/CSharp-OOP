using SimpleSnake.Enums;
using System;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Core
{
internal class PlatformInteractions
{
    public PlatformInteractions()
    {
        Console.CursorVisible = false;
    }

    public static void GameOver(Point fieldTopRightPoint)
    {
        int x = fieldTopRightPoint.X + 1;
        int y = 3;

        Console.SetCursorPosition(x, y);
        Console.WriteLine("Would you like to continue? y/n");

        ConsoleKeyInfo userInput = Console.ReadKey();

        if (userInput.Key == ConsoleKey.Y)
        {
            Restart();
        }
        else if (userInput.Key == ConsoleKey.N)
        {
            Exit();
        }
    }

    public static Direction GetInput(Direction currentDirection)
    {
        ConsoleKeyInfo userInput = Console.ReadKey();

        if (userInput.Key == ConsoleKey.LeftArrow)
        {
            if (currentDirection != Direction.Right)
            {
                currentDirection = Direction.Left;
            }
        }
        else if (userInput.Key == ConsoleKey.RightArrow)
        {
            if (currentDirection != Direction.Left)
            {
                currentDirection = Direction.Right;
            }
        }
        else if (userInput.Key == ConsoleKey.UpArrow)
        {
            if (currentDirection != Direction.Down)
            {
                currentDirection = Direction.Up;
            }
        }
        else if (userInput.Key == ConsoleKey.DownArrow)
        {
            if (currentDirection != Direction.Up)
            {
                currentDirection = Direction.Down;
            }
        }

        return currentDirection;
    }


    public static void Draw(Point point, char symbol)
    {
        Console.SetCursorPosition(point.X, point.Y);
        Console.Write(symbol);
    }

    public static void Restart()
    {
        Console.Clear();
        StartUp.Main();
    }

    public static void Exit()
    {
        Console.SetCursorPosition(20, 10);
        Console.Write("Game over!");
        Environment.Exit(1);
    }
}
}
