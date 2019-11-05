using System;

namespace LRouge
{
    internal abstract class Creature : IDrawable
    {
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
        public string Symbol { get; } = "C ";
        public Cell Cell { get; set; }


        public bool IsDead => Health <= 0;
        public int Damage { get; set; }
        private int health;
        public int Maxhealth { get; set; } = 100;
        public int Health 
        { 
            get { return health; }
            set 
            {
                if (health + value >= Maxhealth) health = Maxhealth;
                else health = value;
            } 
        }

        public Creature(Cell cell, string symbol)
        {
            Symbol = symbol;
            Cell = cell;
            health = Maxhealth;
        }
    }
}