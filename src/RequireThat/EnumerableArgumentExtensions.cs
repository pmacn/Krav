using RequireThat.Resources;
using System.Collections;
using System.Diagnostics;

namespace RequireThat
{
    public static class EnumerableArgumentExtensions
    {
        /// <summary>
        /// Requires that the <paramref name="argument"/> is not empty.
        /// Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <seealso cref="RequireThat.Argument"/> to add the requirement to.</param>
        /// <returns>The <seealso cref="RequireThat.Argument"/> that the extension was called on.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsNotEmpty<T>(this Argument<T> argument)
            where T : IEnumerable
        {
            return argument.IsNotEmpty(ExceptionMessages.EmptyCollection);
        }

        /// <summary>
        /// Requires that the <paramref name="argument"/> is not empty.
        /// Throws an exception with the specified <paramref name="message"/> if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <seealso cref="RequireThat.Argument"/> to add the requirement to.</param>
        /// <param name="message">Message to use in the <seealso cref="ArgumentException"/>.</param>
        /// <returns>The <seealso cref="RequireThat.Argument"/> that the extension was called on.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsNotEmpty<T>(this Argument<T> argument, string message)
            where T : IEnumerable
        {
            if (argument.Value == null || !argument.Value.GetEnumerator().MoveNext())
                throw ExceptionFactory.CreateArgumentException(argument, message);
            
            return argument;
        }
    }
}