namespace Krav
{
    using System;

    /// <summary>
    /// Provides helper methods for constructing standard exception types used in argument validation.
    /// </summary>
    internal static class ExceptionFactory
    {
        /// <summary>
        /// Creates an <see cref="ArgumentException"/> using the specified argument and message.
        /// </summary>
        /// <typeparam name="T">The type of the argument being validated.</typeparam>
        /// <param name="argument">The argument that caused the validation failure.</param>
        /// <param name="message">The exception message to include.</param>
        /// <returns>A new <see cref="ArgumentException"/> instance.</returns>
        public static ArgumentException CreateArgumentException<T>(Argument<T> argument, string message)
        {
            return new ArgumentException(message, argument.Name);
        }

        /// <summary>
        /// Creates an <see cref="ArgumentNullException"/> for a <c>null</c> argument.
        /// </summary>
        /// <typeparam name="T">The type of the argument being validated.</typeparam>
        /// <param name="argument">The argument that was <c>null</c>.</param>
        /// <returns>A new <see cref="ArgumentNullException"/> instance.</returns>
        public static ArgumentNullException CreateNullException<T>(Argument<T> argument)
        {
            return new ArgumentNullException(argument.Name, ExceptionMessages.Current.WasNull);
        }

        /// <summary>
        /// Creates an <see cref="ArgumentOutOfRangeException"/> using the specified argument and message.
        /// </summary>
        /// <typeparam name="T">The type of the argument being validated.</typeparam>
        /// <param name="argument">The argument that was out of range.</param>
        /// <param name="message">The exception message to include.</param>
        /// <returns>A new <see cref="ArgumentOutOfRangeException"/> instance.</returns>
        internal static ArgumentOutOfRangeException OutOfRange<T>(Argument<T> argument, string message)
        {
            return new ArgumentOutOfRangeException(argument.Name, message);
        }
    }
}
