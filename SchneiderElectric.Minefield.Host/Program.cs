using Microsoft.Extensions.DependencyInjection;
using SchneiderElectric.Minefield.Host.Entities;
using SchneiderElectric.Minefield.Host.Extensions;
using SchneiderElectric.Minefield.Host.Field;

class Program
{
    static void Main(string[] args)
    {
        var boardSize = 8;

        var services = new ServiceCollection();
        var serviceProvider = services.Initialize(boardSize);

        var board = serviceProvider.GetRequiredService<IBoard>();

        while (board.StillPlaying())
        {
            board.Display();

            var direction = GetDirection(Console.ReadKey().Key);

            if (direction == Direction.Wrong)
            {
                Console.WriteLine("\n\nInvalid move! Try again.");
                continue;
            }

            board.PlayTurn(direction);
        }

        Console.WriteLine("\n\nGAME OVER");
        Console.WriteLine("\n\nPress any key to exit...");


        Console.ReadKey();
    }

    static Direction GetDirection(ConsoleKey key) => key switch
    {
        ConsoleKey.RightArrow => Direction.Right,
        ConsoleKey.UpArrow => Direction.Up,
        ConsoleKey.LeftArrow => Direction.Left,
        ConsoleKey.DownArrow => Direction.Down,
        _ => Direction.Wrong
    };
}