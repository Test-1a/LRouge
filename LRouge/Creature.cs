using System;

namespace LRouge
{
    internal abstract class Creature : IDrawable
    {
        private ConsoleColor color;
        public ConsoleColor Color 
        {
            get 
            {
                return IsDead ? ConsoleColor.Gray : color;
            }
            set
            {
                color = value;
            }
        }
        public string Symbol { get; } = "C ";
        public Cell Cell { get; set; }
        private string name => this.GetType().Name;


        public bool IsDead => Health <= 0;
        public int Damage { get; set; }
        private int health;

        public int Maxhealth { get; set; }       
        public int Health 
        { 
            get { return health; }
            set 
            {
                if (value >= Maxhealth) health = Maxhealth;
                else health = value;
            } 
        }

        public Action<string> AddMessage { get; set; }

        public Creature(Cell cell, string symbol, int maxHealth)
        {
            Symbol = symbol; 
            Cell = cell;
            Maxhealth = maxHealth;
            Health = maxHealth;
        }

        internal void Attack(Creature target)
        {
            //ToDo recursive
            if (target.IsDead) return;

            var thisName = this.name;
            var targetName = target.name;

            target.Health -= Damage;
            AddMessage($"The {thisName} attacks the {targetName} for {Damage} damage");

            if (target.IsDead)
            {
                AddMessage($"The {targetName} is dead");
                return;
            }
            
            Health -= target.Damage;
            AddMessage($"The {targetName} attacks the {thisName} for {target.Damage} damage");

            if (IsDead)
            {
                AddMessage($"The {thisName} is dead");
                return;
            }
        }
    }
}