using Battleship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Player : BasePlayer
    {


        public void PlaceShips()
        {
            List<Ship> shipsToPlace = new List<Ship>();
            {
                new Ship("Carrier", 5);
                new Ship("BattleShip", 4);
                new Ship("Cruiser", 3);
                new Ship("Submarine", 3);
                new Ship("Destroyer", 2);
            };
            foreach(var ship in shipsToPlace)
            {
                bool placed = false;
                while(!placed)
                {
                    Console.WriteLine($"Place your {ship.Name} (Size {ship.Length})");
                    Console.WriteLine("Enter row (A-J): ");
                    char rowChar = Console.ReadKey().KeyChar;
                    int row = rowChar - 'A';
                    Console.WriteLine("\n Enter Column (0-9): ");
                    int column = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter direction (H for horizontal, V for vertical)");
                    string direction = Console.ReadLine().ToUpper();
                    placed = Grid.PlaceShip(ship, row, column, direction);
                    if(!placed)
                    {
                        Console.WriteLine("Invalid placement. Try Again");
                    }
                }
            }
        }



    }
}
