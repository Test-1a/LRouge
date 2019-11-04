﻿using System;
using System.Collections.Generic;

namespace LRouge
{
    internal class Cell : IDrawable
    {
        public int X { get;  }
        public int Y { get;  }
        public List<Item> Items { get; set; } = new List<Item>();
        public string Symbol => ". ";
        public ConsoleColor Color { get; set; }

        //ToDo: Remove?
        //public Creature Creature { get; set; }

        public Cell(int y, int x)
        {
            Color = ConsoleColor.Red;
            X = x;
            Y = y;
        }

    }
}