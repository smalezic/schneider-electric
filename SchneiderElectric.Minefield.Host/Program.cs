namespace SchneiderElectric.Minefield.Host;

using Microsoft.Extensions.DependencyInjection;
using SchneiderElectric.Minefield.Host.Entities;
using SchneiderElectric.Minefield.Host.Extensions;
using SchneiderElectric.Minefield.Host.Field;
using Microsoft.Extensions.Configuration;

static class Program
{
    static void Main(string[] args)
    {
        var initialValues = ReadConfiguration();

        var services = new ServiceCollection();
        var serviceProvider = services.Initialize(
            initialValues.BoardSize,
            initialValues.NumberOfMines);

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

    static (int BoardSize, int NumberOfMines) ReadConfiguration()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var boardSize = configuration.GetValue<int>("GameSettings:BoardSize");
        var numberOfMines = configuration.GetValue<int>("GameSettings:NumberOfMines");

        return (boardSize, numberOfMines);
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