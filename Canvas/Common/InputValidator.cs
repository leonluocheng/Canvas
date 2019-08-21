using System;
using Canvas.Interfaces;

namespace Canvas.Common
{
    public class InputValidator : IValidator
    {
        public bool IsValidateInputCommand(string input)
        {
            var command = input.TrimStart().TrimEnd();

            if (string.IsNullOrWhiteSpace(command)) return false;

            if(command[0] != 'C' || command[0] != 'L' || command[0] != 'R' || command[0] != 'B')
            {
                return false;
            }

            return true;
        }
    }
}


