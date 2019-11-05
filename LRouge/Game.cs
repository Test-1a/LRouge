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
            ConsoleKey keyPressed = UI.GetKey();

            switch (keyPressed)
            {
                case ConsoleKey.LeftArrow:
                    Move(new Position(0, -1));
                    break;
                case ConsoleKey.UpArrow:
                    Move(new Position(-1, 0));
                    break;
                case ConsoleKey.RightArrow:
                    Move(new Position(0, 1));
                    break;
                case ConsoleKey.DownArrow:
                    Move(new Position(1, 0));
                    break;
            }
        }

        private void Move(Position movement)
        {
            Position newPosition = hero.Cell.Position + movement;
            Cell newCell = map.GetCell(newPosition);
            if (newCell != null) hero.Cell = newCell;
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