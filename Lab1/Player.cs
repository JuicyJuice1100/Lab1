using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Player
    {
        public bool isHuman { get; set; }
        public bool isX { get; set; }

        public Player(bool isHuman, bool isX)
        {
            this.isHuman = isHuman;
            this.isX = isX;
        }

        //private void setIsX(bool isX)
        //{
        //    this.isX = isX;
        //}

        //private void setIsHuman(bool isHuman)
        //{
        //    this.isHuman = isHuman;
        //}

        //private bool getIsHuman()
        //{
        //    return isHuman;
        //}

        //private bool getIsX()
        //{
        //    return isX;
        //}
    }
}
