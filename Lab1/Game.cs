using System;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lab1
{
    public class Game
    {
        const string X = "X";
        const string O = "O";

        public Player player {get;set;}
        public Player computer {get;set;}
        public Board gameBoard {get;set;}
        public bool isPlayerTurn {get;set;}
        public string playerPiece { get; set; }
        public string computerPiece { get; set; }
        public int[] lastMove { get; set; }

        public Game(Player player, Player computer, Board gameBoard)
        {
            this.player = player;
            this.computer = computer;
            this.gameBoard = gameBoard;
        }

        public bool checkIfWon()
        {
            // Check columns
            for (var x = 0; x < 3; x++)
            {
                var firstField = gameBoard.playArea[x , 0];
                if (firstField == null) continue;
                bool allFieldsTheSame = true;

                for (var y = 1; y < 3; y++)
                {
                    if (gameBoard.playArea[x , y] != firstField)
                    {
                        allFieldsTheSame = false;
                        break;
                    }
                }

                if (allFieldsTheSame) return true;
            }

            // Check rows
            for (var y = 0; y < 3; y++)
            {
                var firstField = gameBoard.playArea[0, y];
                if (firstField == null) continue;
                var allFieldsTheSame = true;

                for (var x = 1; y < 3; x++)
                {
                    if (gameBoard.playArea[x, y] != firstField)
                    {
                        allFieldsTheSame = false;
                        break;
                    }
                }

                if (allFieldsTheSame) return true;
            }

            // first diagonal
            if (gameBoard.playArea != null)
            {
                var allFieldsTheSame = true;

                for (var d = 0; d < 3; d++)
                {
                    if (gameBoard.playArea[d, d] != gameBoard.playArea[0 ,0])
                    {
                        allFieldsTheSame = false;
                        break;
                    }
                }
                if (allFieldsTheSame) return true;
            }

            // second diagonal
            if (gameBoard.playArea[2 ,0] != null)
            {
                var allFieldsTheSame = true;
                for (var d = 0; d < 3; d++)
                {
                    if (gameBoard.playArea[d ,3 - d - 1] != gameBoard.playArea[2 ,0])
                    {
                        allFieldsTheSame = false;
                        break;
                    }
                }
                if (allFieldsTheSame) return true;
            }

            return false;
        }

        public bool saveGame()
        {
            //TODO: Export to a text file
            string fileName = null;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    try
                    {
                        string json = JsonConvert.SerializeObject(this);
                        File.WriteAllText(fileName, json);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            Console.WriteLine("Game Saved");

            return true;
        }

        public bool loadGame()
        {
            ////TODO: Import a text file and data
            string fileName = null;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                    try
                    {
                        Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(fileName));
                        this.player = game.player;
                        this.computer = game.computer;
                        this.gameBoard = game.gameBoard;
                        this.isPlayerTurn = game.isPlayerTurn;
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            Console.WriteLine("Game Loaded");

            return true;
        }

        public void playGame(bool playGame)
        {
            bool validInput;

            while (playGame)
            {
                if (isPlayerTurn)
                {
                    validInput = false;
                    Console.WriteLine("Insert move or save & quit (1 = move, 0 = quit");
                    while (!validInput)
                    {
                        switch (int.Parse(Console.ReadLine()))
                        {
                            case 1:
                                while (!validInput)
                                {
                                    string[] tokens = Console.ReadLine().Split();

                                    //Parse element 0
                                    int row = int.Parse(tokens[0]);

                                    //Parse element 1
                                    int column = int.Parse(tokens[1]);

                                    validInput = gameBoard.insertMove(row, column, playerPiece);
                                    if (!validInput)
                                    {
                                        Console.WriteLine("Please put a valid move");
                                    }
                                    lastMove = new int[2] { row, column };
                                }
                                break;
                            case 0:
                                saveGame();
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Please put a valid command");
                                break;
                        }
                        
                    }
                    if (checkIfWon())
                    {
                        Console.Write("You Win");
                        Environment.Exit(0);
                    };
                    
                    isPlayerTurn = false;
                }
                else
                {
                    gameBoard.randomMove(computerPiece);
                    if (checkIfWon())
                    {
                        Console.Write("You Lose");
                        Environment.Exit(0);
                    };
                    isPlayerTurn = true;
                }
            }
        }

        public void newGame()
        {
            Random firstPlay = new Random();
            bool validInput = false;
            bool playGame = true;
            while (!validInput)
            {
                Console.WriteLine("Play as X or O? (X = 1 O = 0)");
                switch (Console.ReadLine().ToUpper())
                {
                    case X:
                        player.isX = true;
                        computer.isX = false;
                        validInput = true;
                        playerPiece = X;
                        computerPiece = O;
                        validInput = true;
                        break;
                    case O:
                        player.isX = false;
                        computer.isX = true;
                        validInput = true;
                        playerPiece = O;
                        computerPiece = X;
                        validInput = true;
                        break;
                    default:
                        Console.WriteLine("Please put a valid input");
                        break;
                }
            }

            isPlayerTurn = firstPlay.Next(2) < 2;

            this.playGame(playGame);
        }
    }
}
