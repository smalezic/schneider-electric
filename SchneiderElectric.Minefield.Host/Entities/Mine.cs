namespace SchneiderElectric.Minefield.Host.Entities;

internal class Mine : BaseEntity
{
    public Mine(int positionX, int positionY)
        : base(positionX, positionY)
    {
        PositionX = positionX;
        PositionY = positionY;
    }
}