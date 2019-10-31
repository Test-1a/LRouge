using System;

namespace LRouge
{
    internal class Game
    {
        private Map map;
        private Hero hero;
        private bool gameInProgress;

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
            //do
            do
            {

                Draw();
                 //draw map
                 //get command
                 //execute action
                 //draw map
                 //enemy actions
                 //draw map

            } while (gameInProgress);
               //while game in progress
        }

        private void Draw()
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