using System;
using System.Linq;

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

                //draw map
                DrawMap();
                //get command
                GetInput();
                //execute action
                //draw map
                DrawMap();
                //enemy actions
                //draw map

            } while (true);
            //while game in progress
        }

        private void GetInput()
        {
            var keyPressed = UI.GetKey();

            switch (keyPressed)
            {
                
                case ConsoleKey.LeftArrow:
                   Move(hero.Cell.X - 1, hero.Cell.Y);
                    break;
                case ConsoleKey.UpArrow:
                   Move(hero.Cell.X, hero.Cell.Y - 1);
                    break;
                case ConsoleKey.RightArrow:
                   Move(hero.Cell.X + 1, hero.Cell.Y);
                    break;
                case ConsoleKey.DownArrow:
                   Move(hero.Cell.X, hero.Cell.Y + 1);
                    break;
                default:
                    break;
            }
        }

        private void Move(int x, int y)
        {
            var moveToCell = map.GetCell(y,x);
            if (moveToCell != null) hero.Cell = moveToCell;
        }

        private void DrawMap()
        {
            UI.Clear(); 
            UI.Draw(map);
           
            
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