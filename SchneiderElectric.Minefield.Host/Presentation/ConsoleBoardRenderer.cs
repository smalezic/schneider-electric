using SchneiderElectric.Minefield.Host.Entities;

namespace SchneiderElectric.Minefield.Host.Presentation
{
    internal class ConsoleBoardRenderer : IBoardRenderer
    {
        public void DisplayBoard(Player player, int size)
        {
            var letterOffset = 65;

            Console.WriteLine($"\n\nYou have made {player.MoveCounter} moves so far.");
            Console.WriteLine($"You have {player.LifeCounter} lives remaining.");
            Console.WriteLine("Current Board:");

            for (int row = 0; row < size; row++)
            {
                Console.Write($"{size - row} ");
                for (int col = 0; col < size; col++)
                {
                    if (col == player.PositionX && row == player.PositionY)
                    {
                        Console.Write("O ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }

            Console.Write("  ");
            for (int col = 0; col < size; col++)
            {
                Console.Write($"{((char)(letterOffset + col)).ToString()} ");
            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine("\n\n************************");
            Console.WriteLine(message);
            Console.WriteLine("************************");
        }
    }
}