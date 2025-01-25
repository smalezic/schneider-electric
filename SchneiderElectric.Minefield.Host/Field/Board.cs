using SchneiderElectric.Minefield.Host.Entities;
using SchneiderElectric.Minefield.Host.Presentation;

namespace SchneiderElectric.Minefield.Host.Field;

internal class Board : IBoard
{
    private const int NumberOfMines = 10;

    public IBoardRenderer Renderer { get; init; }
    private int Size { get; init; }
    private List<Mine> Mines { get; init; }
    private Player Rabbit { get; init; }

    private Board(IBoardRenderer renderer, int size)
    {
        Renderer = renderer;
        this.Size = size;

        this.Mines = new List<Mine>(NumberOfMines);
        PutMinesInLandfield();

        this.Rabbit = new Player(0,0);
    }

    public static IBoard Create(IBoardRenderer renderer, int size)
    {
        if (size < 4
            || size > 9)
        {
            throw new ArgumentOutOfRangeException(nameof(size));
        }

        if (renderer is null)
        {
            throw new ArgumentNullException(nameof(renderer));
        }

        return new Board(renderer, size);
    }

    public void Display()
    {
        Renderer.DisplayBoard(Rabbit, Size);
    }

    public bool StillPlaying()
    {
        if (Rabbit.LifeCounter == 0)
        {
            Renderer.DisplayMessage("Sorry, you lost");
            return false;
        }
        if (Rabbit.PositionX == Size - 1 && Rabbit.PositionY == Size - 1)
        {
            Renderer.DisplayMessage("Congratulations, you won");
            return false;
        }

        return true;
    }

    public void PlayTurn(Direction direction)
    {
        Rabbit.Move(direction, Size);
        
        if (DetectCollision())
        {
            Rabbit.Die();
        }
    }

    private void PutMinesInLandfield()
    {
        var random = new Random();
        var placedMines = new HashSet<(int, int)>();

        while (placedMines.Count < NumberOfMines)
        {
            int x = random.Next(Size);
            int y = random.Next(Size);
            if (placedMines.Add((x, y)))
            {
                Mines.Add(new Mine(x, y));
            }
        }
    }

    private bool DetectCollision()
    {
        return Mines.Exists(mine =>
            mine.PositionX == Rabbit.PositionX
            && mine.PositionY == Rabbit.PositionY);
    }
}