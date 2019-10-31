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

                DrawMap();
                 //draw map
                 //get command
                 //execute action
                 //draw map
                 //enemy actions
                 //draw map

            } while (gameInProgress);
               //while game in progress
        }

        private void DrawMap()
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    var cell = map.GetCell(y, x);
                    Console.Write(cell.Symbol);
                }
                Console.WriteLine();
            }
        }

        private void Initialize()
        {
            //ToDo: Read from config later
             map = new Map(width: 10, height: 10);
             hero = new Hero();
        }
    }
}