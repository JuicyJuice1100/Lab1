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
        private const int newGame = 1;
        private const int loadGame = 2;

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
            
            while (true)
            {
                Console.WriteLine("Select a command (1 = Start new Game, 2 = Load Game, 0 = exit");
                int command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case exit:
                        Environment.Exit(0);
                        break;
                    case loadGame: case newGame:
                        if(command == loadGame)
                        {
                            game.loadGame();
                            game.playGame(game.isPlayerTurn);
                        }
                        else
                        {
                            game.newGame();
                        }
                        //TODO: run commands for new game
                        
                        break;
                    default:
                        Console.WriteLine("Please put a valid command");
                        break;
                }
            }
        }
    }
}
