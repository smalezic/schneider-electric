namespace SchneiderElectric.Minefield.Host.Presentation;

using SchneiderElectric.Minefield.Host.Entities;

internal interface IBoardRenderer
{
    void DisplayBoard(Player player, int size);
    void DisplayMessage(string message);
}