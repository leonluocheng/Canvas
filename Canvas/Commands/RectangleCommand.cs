using Canvas.Interfaces;
using Canvas.Components;

namespace Canvas.Commands
{
    public class RectangleCommand : ICommand
    {
        private readonly ICanvas _canvas;
        private readonly Point _pointA;
        private readonly Point _poingB;

        public RectangleCommand(ICanvas canvas, Point pointA, Point pointB)
        {
            _canvas = canvas;
            _pointA = pointA;
            _poingB = pointB;
        }

        public void Execute()
        {
            _canvas.DrawRectangle(_pointA, _poingB);
        }
    }
}
