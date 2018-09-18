using System;


namespace Lab1
{
   
    class Program
    {
        private const string X = "X";
        private const string O = "O";
        private const string newColumn = "|";
        private const string newRow = "-+-+-";
        private const string playerOne = "playerOne";
        private const string playerTwo = "playerTwo";
        private const int exit = 0;

        [STAThread]
        private static void Main(string[] args)
        {
            //TODO: create everything for the game, get inputs from user
            //while (true)
            //{
                Player player = new Player(true, true);
                Player computer = new Player(false, false);
                Board board = new Board();
                Game game = new Game(player, computer, board);
                game.loadGame();
                game.saveGame();
            //}
        }
    }
}
