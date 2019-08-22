using System;

namespace Canvas.Common
{
    public static class StringParser
    {
        public static int StringToInt(this string arg)
        {
            if (!int.TryParse(arg, out int result) || result < 1)
                throw new ArgumentException();

            return result;
        }

        public static char StringToChar(this string arg)
        {
            if (!char.TryParse(arg, out char result))
                throw new ArgumentException();

            return result;
        }
    }
}
