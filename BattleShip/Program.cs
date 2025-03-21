using Battleship;

namespace BattleShip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] titleScreen =
            {
             " ____      _  _  _          _    _     ",
             "| __ ) __ _| |_| | ___ ___| |__ (_)_ __  ",
             "|  _ \\ / _' | __| __| |/ _ \\/  __| '_ \\| | '_ \\ ",
             "| |_) | (_|| | |_| |_| |  __/\\__ \\ | | | | |_) |",
             "|____/ \\__,_|\\__|_|\\___||___/_| |_|_| ._/",
            };
            Console.WriteLine("Press any key to start....");
            BasePlayer player = new BasePlayer();
            BasePlayer ai = new BasePlayer();
            Grid aiGrid = ai.GetGrid();
            Grid playerGrid = player.GetGrid();
            int shots = 0;

            Console.WriteLine("Welcome to Battleship! Press Enter to start.");
            Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("AI's Board (Shots Fired):");
                aiGrid.DisplayBoard(false);

                Console.WriteLine("\nYour Board:");
                playerGrid.DisplayBoard(false);
                Console.WriteLine("Enter to fire random shots");
                Console.ReadLine();
                player.Attack(aiGrid);

                shots++;
                if (aiGrid.CheckWin())
                {
                    Console.WriteLine("You win in " + shots + " shots!");
                    break;
                }
                ai.Attack(playerGrid);
                if (playerGrid.CheckWin())
                {
                    Console.WriteLine("AI wins!");
                    break;
                }
            }
        }
    }
}
