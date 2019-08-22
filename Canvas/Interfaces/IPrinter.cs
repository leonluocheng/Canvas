namespace Canvas.Interfaces
{
    public interface IPrinter
    {
        void Print(char character);
        void Print(string line);
        void ChangeLine();
    }
}
