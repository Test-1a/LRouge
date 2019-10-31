using System;

namespace LRouge
{
    internal class Game
    {
        private Map map;
        private Hero hero;
        public Game()
        {
        }

        internal void Run()
        {
            Initialize();
            Play();
        }

        private void Play()
        {
            
        }

        private void Initialize()
        {
            //ToDo: Read from config later
             map = new Map(width: 10, height: 10);
             hero = new Hero();
        }
    }
}