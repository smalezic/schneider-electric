using SchneiderElectric.Minefield.Host.Entities;

namespace SchneiderElectric.Minefield.Host.Field;

internal interface IBoard
{
    void Display();
    bool StillPlaying();
    void PlayTurn(Direction direction);
}