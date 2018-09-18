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
        public Player player {get;set;}
        public Player computer {get;set;}
        public Board gameBoard {get;set;}
        public bool isPlayerTurn {get;set;}

        public Game(Player player, Player computer, Board gameBoard)
        {
            this.player = player;
            this.computer = computer;
            this.gameBoard = gameBoard;
        }

        public bool checkIfWon()
        {
            //TODO: logic for win
            return true;
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
    }
}
