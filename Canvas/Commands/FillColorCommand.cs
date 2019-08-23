using Canvas.Interfaces;
using Canvas.Components;

namespace Canvas.Commands
{
    public class FillColorCommand : ICommand
    {
        private readonly ICanvas _canvas;
        private readonly Point _point;
        private readonly char _char;

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
