using RequireThat.Resources;
using System.Collections;
using System.Diagnostics;

namespace RequireThat
{
    /// <summary>
    ///   Requirements for <see cref="T:RequireThat.Argument"/>s of <see cref="T:System.Collections.IEnumerable"/>
    /// </summary>
    public static class EnumerableArgumentExtensions
    {
        /// <summary>
        ///   Requires that the <paramref name="argument"/> is not empty. Throws an exception if the
        ///   requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:RequireThat.Argument"/> to verify.</param>
        /// <returns>The verified <see cref="T:RequireThat.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsNotEmpty<T>(this Argument<T> argument)
            where T : IEnumerable
        {
            return argument.IsNotEmpty(ExceptionMessages.EmptyCollection);
        }

        /// <summary>
        ///   Requires that the <paramref name="argument"/> is not empty. Throws an exception with the
        ///   specified <paramref name="message"/> if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:RequireThat.Argument"/> to verify.</param>
        /// <param name="message">Exception message to use if the requirement fails.</param>
        /// <returns>The verified <see cref="T:RequireThat.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsNotEmpty<T>(this Argument<T> argument, string message)
            where T : IEnumerable
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateNullException(argument, message);

            if (!argument.Value.GetEnumerator().MoveNext())
                throw ExceptionFactory.CreateArgumentException(argument, message);
            
            return argument;
        }
    }
}