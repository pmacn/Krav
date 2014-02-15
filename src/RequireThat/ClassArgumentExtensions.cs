using RequireThat.Resources;
using System;
using System.Diagnostics;

namespace RequireThat
{
    /// <summary>
    ///   Requirements for <see cref="T:RequireThat.Argument"/>s of reference types
    /// </summary>
    public static class ClassArgumentExtensions
    {
        /// <summary>
        ///   Requires that the <paramref name="argument"/> is not null. Throws an exception if the
        ///   requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:RequireThat.Argument"/> to verify.</param>
        /// <returns>The verified <see cref="T:RequireThat.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the requirement is not met.</exception>
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
        /// <param name="argument">The <see cref="T:RequireThat.Argument"/> to verify.</param>
        /// <param name="message">Exception message to use if the requirement fails.</param>
        /// <returns>The verified <see cref="T:RequireThat.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the requirement is not met.</exception>
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