using System;

namespace LRouge
{
    internal interface IDrawable
    {
        ConsoleColor Color { get; set; }
        string Symbol { get; }
    }
}