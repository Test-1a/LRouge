using System;
using LimitedList;

namespace LRouge
{
    internal class Hero : Creature
    {
        public LimitedList<Item>  Backpack { get; set; }
        public Hero(Cell cell) : base(cell, "H ", 100)
        {
            Color = System.ConsoleColor.Yellow;
            Backpack = new LimitedList<Item>(2);
            Damage = 20;
        }

        
    }
}