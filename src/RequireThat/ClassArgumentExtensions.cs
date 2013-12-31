using RequireThat.Resources;
using System;
using System.Diagnostics;

namespace RequireThat
{
    public static class ClassArgumentExtensions
    {
        /// <summary>
        ///   Requires that the <paramref name="argument"/> is not null. Throws an exception if the
        ///   requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">
        ///   The <seealso cref="RequireThat.Argument"/> to add the requirement to.
        /// </param>
        /// <returns>
        ///   The <seealso cref="RequireThat.Argument"/> that the extension was called on.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsNotNull<T>(this Argument<T> argument)
            where T : class
        {
            return argument.IsNotNull(ExceptionMessages.WasNull);
        }

        /// <summary>
        ///   Requires that the <paramref name="argument"/> is not null. Throws an exception with the
        ///   specified <paramref name="message"/> if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">
        ///   The <seealso cref="RequireThat.Argument"/> to add the requirement to.
        /// </param>
        /// <param name="message">Message to use in the <seealso cref="ArgumentException"/>.</param>
        /// <returns
        ///   The <seealso cref="RequireThat.Argument"/> that the extension was called on.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsNotNull<T>(this Argument<T> argument, string message)
            where T : class
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateNullException(argument, message);

            return argument;
        }
    }
}