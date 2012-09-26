using System;
namespace MyNes.Core.Exceptions
{
    public class ReadRomFailedException : Exception
    {
        public ReadRomFailedException(string message)
            : base(message)
        { }
    }
}
