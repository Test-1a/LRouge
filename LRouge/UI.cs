using System;
using System.Linq;
using LimitedList;

namespace LRouge
{
    internal static class UI
    {
        private static MessageLog<string> messageLog = new MessageLog<string>(6);

        public static void AddMessage(string message) => messageLog.Add(message);

        internal static void DrawMap(Map map)
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Cell cell = map.GetCell(y, x);

                    //IDrawable drawable = map.CreatureAt(cell) ?? cell;
                        IDrawable drawable = map.Creatures.CreatureAtExten(cell) ?? 
                        (IDrawable)cell.Items.FirstOrDefault() ?? 
                        cell;
                    
                    Console.ForegroundColor = drawable?.Color ?? ConsoleColor.White;
                    Console.Write(drawable?.Symbol);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal static void PrintStats(string stats)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(stats);
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

        internal static void PrintLog()
        {
            messageLog.WriteAll(m => Console.WriteLine(m));
            //messageLog.WriteAll(Print);
        }

        //private static void Print(string mess)
        //{
        //    Console.WriteLine(mess);
        //}

       
    }
}