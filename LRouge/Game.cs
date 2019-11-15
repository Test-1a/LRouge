using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LRouge
{
    internal class Game
    {
        private Map map;
        private Hero hero;
        private bool gameInProgress = true;
        private readonly IConfiguration configuration;

        public Game(IConfiguration configuration)
        {
            this.configuration = configuration;
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
                Draw();
                //get command
                GetInput();
                //execute action
                //draw map
                Draw();
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
                case ConsoleKey.Q:
                    gameInProgress = false;
                    break;
            }

            var actionMeny = new Dictionary<ConsoleKey, Action>()
            {
                { ConsoleKey.P, PickUp },
                {ConsoleKey.I, Inventory }
            };

            if (actionMeny.ContainsKey(keyPressed)) actionMeny[keyPressed].Invoke();
        }

        private void Inventory()
        {
            var counter = 1;
            var builder = new StringBuilder();
            builder.AppendLine("Inventory:");
            foreach (var item in hero.Backpack)
            {
                builder.AppendLine($"{counter}: \t{item}");
                counter++;
            }
            UI.AddMessage(builder.ToString());
        }

        private void PickUp()
        {
            if (hero.Backpack.IsFull)
            {
                UI.AddMessage("Backpack is full");
                return;
            }

            var items = hero.Cell.Items;
            var item = items.FirstOrDefault();
            if (item == null) return;
            if (hero.Backpack.Add(item))
            {
                UI.AddMessage($"Hero picks up {item.ToString()}");
                items.Remove(item);
            }

        }

        private void Move(Position movement)
        {
            Position newPosition = hero.Cell.Position + movement;
            Cell newCell = map.GetCell(newPosition);

            var opponent = map.CreatureAt(newCell) as Creature;
            if (opponent != null) hero.Attack(opponent);
            if (newCell != null) hero.Cell = newCell;
        }

        private void Draw()
        {
            UI.Clear();
            UI.DrawMap(map);
            UI.PrintStats($"Health: {hero.Health}\nEnemys: {map.Creatures.Count}\n______________");
            UI.PrintLog();


        }

        private void Initialize()
        {
            //Important! Go to properties for appsettings.json set property: "Copy to output directory" to "Copy if newer"
            var mapSettings = configuration.GetSection("LRouge:MapSettings");
            int.TryParse(mapSettings["X"], out int width);
            int.TryParse(mapSettings["Y"], out int height);

            map = new Map(width, height);
            AddCreaturesAndItems(width, height);
        }

        private void AddCreaturesAndItems(int width, int height)
        {
             
            var heroCell = map.GetCell(0, 0);
            hero = new Hero(heroCell);
            map.Creatures.Add(hero);

            var random = new Random();
            map.Creatures.Add(new Goblin(map.GetCell(random.Next(0, height), random.Next(0, width))));
            map.Creatures.Add(new Goblin(map.GetCell(random.Next(0, height), random.Next(0, width))));
            map.Creatures.Add(new Ogre  (map.GetCell(random.Next(0, height), random.Next(0, width))));
            map.Creatures.Add(new Ogre  (map.GetCell(random.Next(0, height), random.Next(0, width))));
            map.Creatures.Add(new Ogre  (map.GetCell(random.Next(0, height), random.Next(0, width))));

            map.Creatures.ForEach(c => c.AddMessage = UI.AddMessage);
            map.Creatures.ForEach(c => c.AddMessage += (s) => Debug.WriteLine(s));


            map.GetCell(random.Next(0, height), random.Next(0, width)).Items.Add(Item.Coin());
            map.GetCell(random.Next(0, height), random.Next(0, width)).Items.Add(Item.Coin());
            map.GetCell(random.Next(0, height), random.Next(0, width)).Items.Add(Item.Coin());
            map.GetCell(random.Next(0, height), random.Next(0, width)).Items.Add(Item.Hat());
             
        }
    }
}