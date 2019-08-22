using Canvas.Components;
namespace Canvas.Interfaces
{
    public interface ICanvas
    {
        void Create(int width, int height);
        void DrawLine(Point pointA, Point pointB);
        void DrawRectangle(Point pointA, Point pointB);
        void FillColor(Point point, char character);
    }
}
