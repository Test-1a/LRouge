using System;
using System.Collections.Generic;

namespace LRouge
{
    internal class Cell : IDrawable
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public string Symbol => ". ";
        public ConsoleColor Color { get; set; }

        //ToDo: Remove?
        //public Creature Creature { get; set; }

        public Cell()
        {
            Color = ConsoleColor.Red;
        }

    }
}