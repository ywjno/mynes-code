using System;
namespace MyNes.Core.Exceptions
{
    public class NotSupportedMapperException : Exception
    {
        public NotSupportedMapperException(string message)
            : base(message)
        { }
    }
}
