using System;
using Canvas.Interfaces;

namespace Canvas
{
    public class StartUp : IStartUp
    {
        private readonly IParser _parser;
        private ICommand _command;
        public StartUp(IParser parser)
        {
            _parser = parser;
        }

        public void Run()
        {
            while (true)
            {
                Console.Write("enter command: ");
                var line = Console.ReadLine();
                if (line == "Q" || line == "q")
                {
                    break;
                }
                try
                {
                    _command = _parser.ParseCommand(line);
                    _command.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
