
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bamms6practa
{
    public class Editor
    {
        public static string Open(List<Figure> data)
        {
            string text = Converters.GetText(data);
            string[] lines = text.Split("\n");
            int position = 0;
            int limit = lines.Count();
            while (position >= 0)
            {
                Console.Clear();
                foreach (string line in lines)
                {
                    Console.WriteLine("  " + line);
                }
                Console.SetCursorPosition(0, position);
                Console.Write("=>");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (position != 0)
                        {
                            position--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (position != limit)
                        {
                            position++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.SetCursorPosition(0, limit + 2);
                        Console.Write("Исправление строки: ");
                        lines[position] = Console.ReadLine();
                        break;
                    case ConsoleKey.F1:
                        position = -1;
                        break;
                }
            }
            text = String.Join("\n", lines);
            return text;
        }
    }
}