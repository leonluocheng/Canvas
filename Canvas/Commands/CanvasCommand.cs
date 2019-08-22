using System;
using Canvas.Interfaces;
using Canvas.Components;

namespace Canvas.Commands
{
    public class CanvasCommand : ICommand
    {
        private ICanvas _canvas;
        private int _width;
        private int _height;

        public CanvasCommand(ICanvas canvas, int width, int height)
        {
            _canvas = canvas;
            _width = width;
            _height = height;
        }

        public void Execute()
        {
            _canvas.Create(_width, _height);
        }
    }
}
