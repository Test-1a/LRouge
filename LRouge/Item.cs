using System;

namespace LRouge
{
    public class Item : IDrawable
    {
        public ConsoleColor Color { get; set; }
        public string Symbol { get; }
        private string name;

        public Item(string symbol, ConsoleColor color, string name)
        {
            Symbol = symbol;
            Color = color;
            this.name = name;
        }

        public static Item Coin() => new Item("c ", ConsoleColor.Yellow, "Coin");
        public static Item Hat() => new Item("h ", ConsoleColor.DarkYellow, "Hat");

        public override string ToString() => name;
      

    }
}