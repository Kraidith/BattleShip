using Battleship;
namespace BattleShip
{
    internal class Player : BasePlayer
    {
        private Grid playerGrid;

        public Player(Grid grid) 
        {
            this.playerGrid = grid;
        }

        public override void PlaceShips()
        {
            List<Ship> shipsToPlace = new List<Ship>
            {
                new Ship("Carrier", 5),
                new Ship("BattleShip", 4),
                new Ship("Cruiser", 3),
                new Ship("Submarine", 3),
                new Ship("Destroyer", 2)
            };
            foreach (var ship in shipsToPlace)
            {
                bool placed = false;
                while (!placed)
                {
                    Console.WriteLine($"Place your {ship.Name} (Size {ship.Length})");
                    int row = -1;
                    while(row < 0 || row > 9)
                    {
                        Console.WriteLine("Enter row (A - J): ");
                        char rowChar = char.ToUpper(Console.ReadKey().KeyChar);
                        Console.WriteLine();
                        if (rowChar >= 'A' && rowChar <= 'J')
                        {
                         row = rowChar - 'A';
                        }
                        else
                        {
                            Console.WriteLine("Invalid row. Try Again");
                        }
                        int column;
                        Console.WriteLine("\n Enter Column (0-9): ");
                        while(!int.TryParse(Console.ReadLine(), out column) || column < 0 || column > 9)
                        {
                            Console.WriteLine("Invalid input. Enter a number between 0-9.");
                        }
                        Console.WriteLine("Enter direction (H for horizontal, V for vertical)");
                        string direction = Console.ReadLine().ToUpper();
                        placed = grid.PlaceShip(ship, row, column, direction);
                        if(!placed)
                        {
                            Console.WriteLine("Invalid placement. Try Again");
                        }
                    }
                }
            }
        }
    }
}
