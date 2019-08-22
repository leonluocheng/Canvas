using System;
namespace Canvas.Exceptions
{
    public class ErrorCommandException : Exception
    {
        public ErrorCommandException(string msg):base(msg)
        {
        }
    }
}
