﻿using System.Collections.Generic;

namespace LRouge
{
    internal class Cell
    {
        public List<Item> Items { get; set; } = new List<Item>();
        private readonly string symbol;

        public Cell()
        {
            symbol = ".";
        }

    }
}