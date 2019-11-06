using System;
using System.Linq;

namespace LRouge
{
    internal class Game
    {
        private Map map;
        private Hero hero;
        private bool gameInProgress = true;

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

            } while (gameInProgress);
            //while game in progress
        }

        private void GetInput()
        {
            ConsoleKey keyPressed = UI.GetKey();

            switch (keyPressed)
            {
                case ConsoleKey.LeftArrow:
                    Move(Direction.W);
                    break;
                case ConsoleKey.UpArrow:
                    Move(Direction.N);
                    break;
                case ConsoleKey.RightArrow:
                    Move(Direction.E);
                    break;
                case ConsoleKey.DownArrow:
                    Move(Direction.S);
                    break; 
                case ConsoleKey.P:
                    PickUp();
                    break; 
                case ConsoleKey.I:
                    Inventory();
                    break;
                case ConsoleKey.Q:
                    gameInProgress = false;
                    break;
            }
        }

        private void Inventory()
        {
            foreach (var item in hero.Backpack)
            {
                Console.WriteLine(item);
            }
        }

        private void PickUp()
        {
            var items = hero.Cell.Items;
            var item = items.FirstOrDefault();
            if (item == null) return;
            if (hero.Backpack.Add(item)) items.Remove(item);

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
            map.Creatures.Add(new Goblin(map.GetCell(4,7)));
            map.Creatures.Add(new Goblin(map.GetCell(2,9)));
            map.Creatures.Add(new Ogre(map.GetCell(2,8)));
            map.Creatures.Add(new Ogre(map.GetCell(8,3)));

            map.GetCell(3, 3).Items.Add(Item.Coin());
            map.GetCell(3, 6).Items.Add(Item.Hat());
            map.GetCell(2, 2).Items.Add(Item.Coin());
            map.GetCell(3, 3).Items.Add(Item.Hat());
        }
    }
}