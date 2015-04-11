namespace Krav
{
    using System;

    internal static class ExceptionFactory
    {
        public static ArgumentException CreateArgumentException<T>(Argument<T> argument, string message)
        {
            return new ArgumentException(message, argument.Name);
        }

        public static ArgumentNullException CreateNullException<T>(Argument<T> argument)
        {
            return new ArgumentNullException(argument.Name, ExceptionMessages.Current.WasNull);
        }

        internal static ArgumentOutOfRangeException OutOfRange<T>(Argument<T> argument, string message)
        {
            return new ArgumentOutOfRangeException(argument.Name, message);
        }
    }
}