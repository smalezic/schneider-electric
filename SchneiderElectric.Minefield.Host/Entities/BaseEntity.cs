namespace SchneiderElectric.Minefield.Host.Entities;

internal abstract class BaseEntity
{
    public int PositionX { get; protected set; }
    public int PositionY { get; protected set; }

    protected BaseEntity(int positionX, int positionY)
    {
        this.PositionX = positionX;
        this.PositionY = positionY;
    }
}