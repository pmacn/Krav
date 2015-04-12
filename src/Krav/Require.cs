namespace Krav
{
    using System;
    using System.Diagnostics;

    /// <summary>
    ///   Access point for creating <see cref="T:Krav.Argument"/>s
    /// </summary>
    public static class Require
    {
        /// <summary>
        ///   Requires that the provided statement is true.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="statement">The statement to validate</param>
        /// <param name="message">Exception message to use if the requirement fails.</param>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static void That(bool statement, string message)
        {
            if (!statement)
            {
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        ///   Creates an <see cref="T:Krav.Argument"/> with the provided value.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="value">The value of the argument.</param>
        /// <returns>An argument with the specified value.</returns>
        [DebuggerStepThrough]
        public static Argument<T> That<T>(T value)
        {
            return new Argument<T>(string.Empty, value);
        }

        /// <summary>
        ///   Creates an <see cref="T:Krav.Argument"/> with the provided value and name.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <returns>An <see cref="T:Krav.Argument"/> with the specified value and name.</returns>
        [DebuggerStepThrough]
        public static Argument<T> That<T>(T value, string name)
        {
            return new Argument<T>(name, value);
        }

        /// <summary>
        ///   Creates an <see cref="T:Krav.Argument"/> from the provided lambda expression.
        /// </summary>
        /// <remarks>
        ///   This function has a significantly larger cost than the non-lamda version, see Performance
        ///   Tests for more details.
        /// </remarks>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="expression">The lamba expression that gives the argument.</param>
        /// <returns>
        ///   An <see cref="T:Krav.Argument"/> with the value and name of the variable in the expression.
        /// </returns>
        [DebuggerStepThrough]
        public static Argument<T> That<T>(Func<T> expression)
        {
            return new Argument<T>(expression);
        }
    }
}