using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consolearrow
{
    internal class arrow
    {
        public static int Show(int minArrow, int maxArrow)
        { 
            int pos = minArrow;
            ConsoleKeyInfo key;
            
            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");

                key = Console.ReadKey();

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.UpArrow && pos != minArrow)
                    pos--;
                else if (key.Key == ConsoleKey.UpArrow && pos == minArrow)
                    pos = maxArrow;
                else if (key.Key == ConsoleKey.DownArrow && pos != maxArrow)
                    pos++;
                else if (key.Key == ConsoleKey.DownArrow && pos == maxArrow)
                    pos = minArrow;
                else if (key.Key == ConsoleKey.Escape)
                    return -90;
            } while (key.Key != ConsoleKey.Enter);
            return pos;
        }
    }
}
