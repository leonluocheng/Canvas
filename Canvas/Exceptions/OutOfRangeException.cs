using System;
namespace Canvas.Exceptions
{
    public class OutOfRangeException : Exception
    {
        public OutOfRangeException(string msg) : base(msg)
        {
        }
    }
}
