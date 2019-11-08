using System;
using System.Collections.Generic;
using System.Text;

namespace LRouge
{
    class Ogre : Creature
    {
        public Ogre(Cell cell)  :base(cell, "O ", 125)
        {
            Color = ConsoleColor.Cyan;
            Damage = 25;
        }
    }
}
