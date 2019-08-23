using Canvas.Interfaces;

namespace Canvas.Commands
{
    public class CanvasCommand : ICommand
    {
        private readonly ICanvas _canvas;
        private readonly int _width;
        private readonly int _height;

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
