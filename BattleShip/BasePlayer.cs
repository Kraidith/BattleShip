namespace Battleship
{
    class BasePlayer
    {
        private Grid grid;
        private Random rand;

        public BasePlayer()
        {
            grid = new Grid();
            rand = new Random();
            PlaceShips();
        }

        public void PlaceShips()
        {
            List<Ship> shipsToPlace = new List<Ship>();
            {
                new Ship("Carrier",5);
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
                    int x = rand.Next(10);
                    int y = rand.Next(10);
                    string direction = rand.Next(2) == 0 ? "H" : "V";
                }
            }
        }

        public bool Attack(Grid enemyGrid)
        {
            int x, y;
            do
            {
                x = rand.Next(10);
                y = rand.Next(10);
            }
            while (enemyGrid.MakeGuess(x, y));
            return true;
        }

        public Grid GetGrid()
        {
            return grid;
        }
    }
}
