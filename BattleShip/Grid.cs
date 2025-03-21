using System.ComponentModel.Design;

namespace Battleship
{
    class Grid
    {
        private char[,] Board;
        public List<Ship> Ships;
        private (int, int) BoardDimensions = (10, 10);
        public Grid()
        {
            Board = new char[BoardDimensions.Item1, BoardDimensions.Item2];
            Ships = new List<Ship>();
            for (int i = 0; i < BoardDimensions.Item1; i++)
            {
                for (int j = 0; j < BoardDimensions.Item2; j++)
                {
                    Board[i, j] = '~';
                }
            }
        }

        public void DisplayBoard(bool hideShips)
        {
            string startLetter = "ABCDEFGHIJ";
            for (int i = 0; i < BoardDimensions.Item1; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");
                }
                for (int j = 0; j < BoardDimensions.Item2; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(startLetter[i] + " ");
                    }
                    char displayChar = Board[i, j];
                    if (hideShips && displayChar == 'S')
                    {
                        displayChar = '~';
                    }
                    Console.Write(displayChar + " ");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        public bool PlaceShip(Ship ship, int startX, int startY, string direction)
        {
            List<(int, int)> tempCoordinates = new List<(int, int)>();
            for (int i = 0; i < ship.Length; i++)
            {
                int x = startX;
                int y = startY;

                if (direction == "V")
                {
                    x += i;
                }
                if (direction == "H")
                {
                    y += i;
                }

                if (x >= 10 || y >= 10 || Board[x, y] != '~')
                {
                    return false;
                }
                tempCoordinates.Add((x, y));
            }
            foreach (var coord in tempCoordinates)
            {
                Board[coord.Item1, coord.Item2] = 'S';
            }
            ship.Coordinates.AddRange(tempCoordinates);
            Ships.Add(ship);
            return true;
        }

        public bool MakeGuess(int x, int y)
        {
            if (Board[x, y] == 'S')
            {
                Board[x, y] = 'X';
                foreach (var ship in Ships)
                {
                    if (ship.Coordinates.Contains((x, y)))
                    {
                        ship.Hits++;
                        return true;
                    }
                }
            }
            else if (Board[x, y] == '~')
            {
                Board[x, y] = 'O';
            }
            return false;
        }
        public void TakeTurn(Grid enemyGrid)
        {
            bool validShot = false;

            while (!validShot)
            {
                char rowChar;
                int row = -1;

                do
                {
                    Console.WriteLine("\nEnter a row (A-J): ");
                    rowChar = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();

                    if (rowChar >= 'A' && rowChar <= 'J')
                    {
                        row = rowChar - 'A';
                    }
                    else
                    {
                        Console.WriteLine("Invalid row. Try Again.");
                    }
                } while (row < 0 || row > 9); 

                Console.WriteLine("Enter a column (0-9): ");
                int column;

                while (!int.TryParse(Console.ReadLine(), out column) || column < 0 || column > 9) // ✅ Fix column validation
                {
                    Console.WriteLine("Invalid input. Enter a number between 0-9.");
                }

                if (enemyGrid.MakeGuess(row, column)) 
                {
                    Console.WriteLine("\nHit!");
                    validShot = true;
                }
                else
                {
                    Console.WriteLine("\nMiss!");
                }
            }
        }




        public bool CheckWin()
        {
            foreach (var ship in Ships)
            {
                if (!ship.IsSunk()) return false;
            }
            return true;
        }
    }
}
