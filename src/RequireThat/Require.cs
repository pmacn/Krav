using System;
using System.Diagnostics;

namespace RequireThat
{
    public static class Require
    {
        /// <summary>
        /// Creates an <seealso cref="RequireThat.Argument"/> with the provided value.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="value">The value of the argument.</param>
        /// <returns>An argument with the specified value.</returns>
        [DebuggerStepThrough]
        public static Argument<T> That<T>(T value)
        {
            return new Argument<T>(String.Empty, value);
        }

        /// <summary>
        /// Creates an <seealso cref="RequireThat.Argument"/> with the provided value and name.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the argument.</param>
        /// <returns>An argument with the specified value.</returns>
        [DebuggerStepThrough]
        public static Argument<T> That<T>(T value, string name)
        {
            return new Argument<T>(name, value);
        }

        /// <summary>
        /// Creates an <seealso cref="RequireThat.Argument"/> from the provided lambda expression. Compiling the
        /// expression to get the value of the argument is several hundred times slower than using the non-lamba
        /// approach. Use this method with caution.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="expression">The lamba expression that gives the argument.</param>
        /// <returns>An argument with the specified value.</returns>
        [DebuggerStepThrough]
        public static Argument<T> That<T>(Func<T> function)
        {
            return new Argument<T>(function);
        }
    }
}