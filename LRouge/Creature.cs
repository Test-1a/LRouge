using System;

namespace LRouge
{
    internal abstract class Creature : IDrawable
    {
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
        public string Symbol { get; } = "C ";
        public Cell Cell { get; }

        public Creature(Cell cell, string symbol)
        {
            Symbol = symbol;
            Cell = cell;
        }
    }
}