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
        private Player player;
        private Player computer;
        private Board gameBoard;
        private bool isPlayerTurn;

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

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                }
            }

            if (fileName != null)
            {
                //Do something with the file, for example read text from it
                //TODO: save json text file
                string text = File.ReadAllText(fileName);
            }
            return true;
        }

        public bool loadGame()
        {
            //TODO: Import a text file and data
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
                }
            }

            if (fileName != null)
            {
                //Do something with the file, for example read text from it
                //TODO: read json string from file
                string text = File.ReadAllText(fileName);
            }
            return true;
        }
    }
}
