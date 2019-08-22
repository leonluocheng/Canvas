using System;
using Canvas.Interfaces;
namespace Canvas.Components
{
    public class Printer : IPrinter
    {
        public void Print(char character)
        {
            Console.Write(character);
        }

        public void Print(string line)
        {
            Console.Write(line);
        }

        public void ChangeLine()
        {
            Console.WriteLine();
        }
    }
}
