using System.Collections.Generic;

namespace LRouge
{
    internal class Cell
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public string Symbol => ". ";

        //ToDo: Remove?
        public Creature Creature { get; set; }

        public Cell()
        {
           
        }

    }
}