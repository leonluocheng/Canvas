namespace Canvas.Interfaces
{
    public interface IParser
    {
        ICommand ParseCommand(string input);
    }
}
