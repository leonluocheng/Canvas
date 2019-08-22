using Canvas.Interfaces;
using Canvas.Components;

namespace Canvas.Commands
{
    public class FillColorCommand : ICommand
    {
        private ICanvas _canvas;
        private Point _point;
        private char _char;

        public FillColorCommand(ICanvas canvas, Point point, char character)
        {
            _canvas = canvas;
            _point = point;
            _char = character;
        }

        public void Execute()
        {
            _canvas.FillColor(_point, _char);
        }
    }
}
