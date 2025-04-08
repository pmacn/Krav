namespace Krav
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///   Access point for creating <see cref="T:Krav.Argument"/>s.
    /// </summary>
    public static class Require
    {
        /// <summary>
        ///   Verifies the provided <paramref name="condition"/>. If the condition is false, throws an exception with the <paramref name="message"/>.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="message">The message to use in the exception if the condition is false.</param>
        /// <exception cref="ArgumentException">Thrown if the condition is false.</exception>
        public static void That(bool condition, string message)
        {
            if (!condition)
            {
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        ///  Creates a new <see cref="T:Krav.Argument"/> for the specified <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="T:System.Type"/> of the argument.</typeparam>
        /// <param name="value">The value to be verified. This can be a primitive type, a reference type or a nullable type.</param>
        /// <param name="name">The name of the argument. This is used in exception messages if the requirement is not met.</param>
        /// <returns>A new <see cref="T:Krav.Argument"/> that can be used to verify the argument.</returns>
        public static Argument<T> That<T>(
            T value,
            [CallerArgumentExpression("value")] string name = "")
        {
            return new Argument<T>(value, name);
        }
    }
}