using System;
using Canvas.Interfaces;

namespace Canvas
{
    public class StartUp : IStartUp
    {
        private IValidator _validator;
        public StartUp(IValidator validator)
        {
            _validator = validator;
        }

        public void Run()
        {
            Console.WriteLine("Hello world!");
        }
    }
}
