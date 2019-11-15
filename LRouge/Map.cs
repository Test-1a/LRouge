using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LRouge
{
    internal class Map
    {
        public int Width { get; }
        public int Height { get; }


        //ToDo: Make comment
        private readonly Cell[,] cells;

        public List<Creature> Creatures { get; set; } = new List<Creature>();

        public Map(IConfigurationRoot configuration)
        {

            Width = configuration.GetMapSizeFor("X");
            Height = configuration.GetMapSizeFor("Y");

            cells = new Cell[Height, Width];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    cells[y, x] = new Cell(new Position(y,x));
                }
            }
        }

        internal IDrawable CreatureAt(Cell cell)
        {
           //Returns creature as IDrawable if the cell contains any creature
           return Creatures.FirstOrDefault(creature => creature.Cell == cell);
        }

        internal Cell GetCell(int y, int x)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return null;
            return cells[y, x];
        }

        internal Cell GetCell(Position newPosition)
        {
            return GetCell(newPosition.Y, newPosition.X);
        }
    }
}