namespace SchneiderElectric.Minefield.Host.Entities;

internal class Player : BaseEntity
{
    public int LifeCounter { get; private set; }
    public int MoveCounter { get; private set; }

    public Player(int positionX, int positionY)
        : base(positionX, positionY)
    {
        LifeCounter = 3;
        MoveCounter = 0;
    }

    public void Move(Direction direction, int limit)
    {
        switch (direction)
        {
            case Direction.Right:
                if (PositionX < limit - 1)
                {
                    PositionX++;
                    MoveCounter++;
                }
                break;

            case Direction.Up:
                if (PositionY > 0)
                {
                    PositionY--;
                    MoveCounter++;
                }
                break;

            case Direction.Left:
                if (PositionX > 0)
                {
                    PositionX--;
                    MoveCounter++;
                }
                break;

            case Direction.Down:
                if (PositionY < limit - 1)
                {
                    PositionY++;
                    MoveCounter++;
                }
                break;

            default:
                throw new InvalidOperationException();
        }
    }

    public void Die()
    {
        --LifeCounter;
    }
}
