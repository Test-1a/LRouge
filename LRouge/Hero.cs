namespace LRouge
{
    internal class Hero : Creature
    {
        public Hero(Cell cell) : base(cell, "H ")
        {
            Color = System.ConsoleColor.Yellow;
        }
    }
}