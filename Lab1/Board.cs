using System;
using System.Collections.Generic;
using System.Text;


namespace Lab1
{
    public class Board
    {
        public string[,] playArea { get; set; }

        public Board()
        {
            playArea = new string[3, 3] { { null, null, null}, { null, null, null}, {null, null, null} };
        }

        private bool insertMove(int row, int column, string move)
        {
            if ((row < 0 || row > 2) && (column < 0 || column > 2) && playArea[row, column] != null)
            {
                return false;
            }
            else
            {
                playArea[row, column] = move;
                return true;
            }
        }

        private bool randomMove(string move)
        {
            Random random = new Random();
            return insertMove(random.Next(3), random.Next(3), move);
        }

        private string[,] getBoard()
        {
            return playArea;
        }


    }
}
