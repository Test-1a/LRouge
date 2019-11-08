using System;
using System.Collections.Generic;
using System.Text;

namespace LRouge
{
    class Goblin : Creature
    {
        public Goblin(Cell cell) : base(cell, "G ", 25)
        {
            Damage = 15;
            Color = ConsoleColor.Green;
        }
    }
}
