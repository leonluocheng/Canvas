using Canvas.Interfaces;
using Canvas.Components;

namespace Canvas.Commands
{
    public class LineCommand : ICommand
    {
        private ICanvas _canvas;
        private Point _pointA;
        private Point _poingB;

        public LineCommand(ICanvas canvas, Point pointA, Point pointB)
        {
            _canvas = canvas;
            _pointA = pointA;
            _poingB = pointB;
        }

        public void Execute()
        {
            _canvas.DrawLine(_pointA, _poingB);
        }
    }
}
