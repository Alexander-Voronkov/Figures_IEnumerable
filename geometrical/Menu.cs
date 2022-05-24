using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Menu
{
    enum HorizontalAlignment
    {
        Center, Left, Right
    };

    enum VerticalAlignment
    {
        Center, Top, Bottom
    };
    static class ConsoleMenu
    {
        public static int SelectVertical(HorizontalAlignment ha,
                                         VerticalAlignment va,
                                         params string[] menuElements)
        {
            List<string> list = menuElements.ToList();
            return SelectVertical(ha, va, list);
        }
        public static int SelectVertical(HorizontalAlignment ha,
                                         VerticalAlignment va,
                                         ICollection<string> menuElements)
        {
            List<string> list = menuElements.ToList();
            int maxLen = list.Max().Length + 5;

            ConsoleColor bg = Console.BackgroundColor;
            ConsoleColor fg = Console.ForegroundColor;

            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            int x = 0;
            switch (ha)
            {
                case HorizontalAlignment.Center: x = width / 2 - maxLen / 2; break;
                case HorizontalAlignment.Left: x = 0; break;
                case HorizontalAlignment.Right: x = width - maxLen; break;
            }

            int y = 0;
            switch (va)
            {
                case VerticalAlignment.Center: y = height / 2 - list.Count / 2; break;
                case VerticalAlignment.Top: y = 0; break;
                case VerticalAlignment.Bottom: y = height - list.Count; break;
            }

            //int x = ha switch
            //{
            //HorizontalAlignment.Center => 40 - maxLen / 2,
            //HorizontalAlignment.Left => 0,
            //HorizontalAlignment.Right: => 80 - maxLen;
            //};


            int pos = 0;
            ConsoleKey consoleKey;
            do
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == pos)
                    {
                        Console.BackgroundColor = fg;
                        Console.ForegroundColor = bg;
                    }
                    else
                    {
                        Console.BackgroundColor = bg;
                        Console.ForegroundColor = fg;
                    }
                    Console.SetCursorPosition(x, y + i);
                    Console.Write(list[i].PadRight(maxLen));
                    Console.SetCursorPosition(x, y + i);
                }
                Console.CursorVisible = false;
                consoleKey = Console.ReadKey().Key;
                Console.CursorVisible = true;
                switch (consoleKey)
                {
                    case ConsoleKey.Escape:
                        return list.Count - 1;

                    case ConsoleKey.UpArrow:
                        if (pos > 0)
                            pos--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (pos < list.Count - 1)
                            pos++;
                        break;

                    default: break;
                }
            } while (consoleKey != ConsoleKey.Enter);

            for (int i = 0; i < 2; i++)
            {
                Console.BackgroundColor = bg;
                Console.ForegroundColor = fg;
                Console.SetCursorPosition(x, y + pos);
                Console.Write(list[pos].PadRight(maxLen));
                Thread.Sleep(250);
                Console.BackgroundColor = fg;
                Console.ForegroundColor = bg;
                Console.SetCursorPosition(x, y + pos);
                Console.Write(list[pos].PadRight(maxLen));
                Thread.Sleep(250);
            }
            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;

            return pos;
        }

        public static int SelectGorizontal(string[] elements)
        {
            return 0;
        }
    }


}
