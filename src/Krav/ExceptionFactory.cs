using System;

namespace Krav
{
    internal static class ExceptionFactory
    {
        public static ArgumentException CreateArgumentException<T>(Argument<T> argument, string message)
        {
            return new ArgumentException(message, argument.Name);
        }

        public static ArgumentNullException CreateNullException<T>(Argument<T> argument, string message)
        {
            return new ArgumentNullException(argument.Name, message);
        }
    }
}