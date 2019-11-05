using System;
using System.Collections.Generic;
using System.Text;

namespace LRouge
{
    class Ogre : Creature
    {
        public Ogre(Cell cell)  :base(cell, "O ")
        {
            Color = ConsoleColor.Cyan;
            Damage = 25;
            Maxhealth = 125;
        }
    }
}
