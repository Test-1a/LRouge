using System;

namespace LRouge
{
    internal static class UI
    {
        internal static void Draw(Map map)
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Cell cell = map.GetCell(y, x);

                    IDrawable drawable = map.CreatureAt(cell) ?? cell;
                
                    Console.ForegroundColor = drawable?.Color ?? ConsoleColor.White;
                    Console.Write(drawable?.Symbol);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal static ConsoleKey GetKey()
        {
            return Console.ReadKey(intercept: true).Key;
        }

        internal static void Clear()
        {
            //Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
        }
    }
}