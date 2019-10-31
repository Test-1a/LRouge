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
                    Cell cell = map.GetCell(y, x);
                    //Console.ForegroundColor = cell?.Color ?? ConsoleColor.White;
                    //Console.Write(cell?.Symbol);
                    IDrawable drawable = cell;

                    foreach (var creature in map.Creatures)
                    {
                        if(creature.Cell == cell)
                        {
                            drawable = creature;
                            break;
                        }
                    }
                    Console.ForegroundColor = drawable?.Color ?? ConsoleColor.White;
                    Console.Write(drawable?.Symbol);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void Initialize()
        {
            //ToDo: Read from config later
            map = new Map(width: 10, height: 10);
            var heroCell = map.GetCell(0, 0);
            hero = new Hero(heroCell);
            map.Creatures.Add(hero);
        }
    }
}