using System;
using Canvas.Interfaces;
using Canvas.Commands;
using Canvas.Components;
using Canvas.Exceptions;

namespace Canvas.Common
{
    public class InputParser : IParser
    {

        private readonly ICanvas _canvas;
        public InputParser(ICanvas canvas)
        {
            _canvas = canvas;
        }

        public ICommand ParseCommand(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException();

            var commandArgs = input.Split(' ');

            var commandType = commandArgs[0].ToUpper();

            switch (commandType)
            {
                case "C":
                    return CreateCanvasCommand(commandArgs);
                case "L":
                    return CreateLineCommand(commandArgs);
                case "R":
                    return CreateRectangleCommand(commandArgs);
                case "B":
                    return CreateFillColorCommand(commandArgs);
                default:
                    throw new ErrorCommandException("Please enter correct command!");
            }

        }

        private ICommand CreateCanvasCommand(string[] commandargs)
        {
            if(commandargs.Length != 3)
                throw new ArgumentException("Invalid canvas command!");

            var width = commandargs[1].StringToInt();
            var height = commandargs[2].StringToInt();

            return new CanvasCommand(_canvas, width, height);
        }

        private ICommand CreateLineCommand(string[] commandargs) 
        {
            if (commandargs.Length != 5)
                throw new ArgumentException("Invalid line command!");

            var pointA = new Point
            {
                X = commandargs[1].StringToInt(),
                Y = commandargs[2].StringToInt()
            };

            var pointB = new Point
            {
                X = commandargs[3].StringToInt(),
                Y = commandargs[4].StringToInt()
            };

            return new LineCommand(_canvas, pointA, pointB);
        }

        private ICommand CreateRectangleCommand(string[] commandargs)
        {
            if (commandargs.Length != 5)
                throw new ArgumentException("Invalid rectangle command!");

            var pointA = new Point
            {
                X = commandargs[1].StringToInt(),
                Y = commandargs[2].StringToInt()
            };

            var pointB = new Point
            {
                X = commandargs[3].StringToInt(),
                Y = commandargs[4].StringToInt()
            };

            return new RectangleCommand(_canvas, pointA, pointB);
        }

        private ICommand CreateFillColorCommand(string[] commandargs)
        {
            if (commandargs.Length != 4)
                throw new ArgumentException("Invalid fill color command!");

            var point = new Point
            {
                X = commandargs[1].StringToInt(),
                Y = commandargs[2].StringToInt()
            };

            var character = commandargs[3].StringToChar();

            return new FillColorCommand(_canvas, point, character);
        }
    }
}