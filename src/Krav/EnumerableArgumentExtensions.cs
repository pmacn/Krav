using System.Collections;
using System.Diagnostics;

namespace Krav
{
    /// <summary>
    ///   Requirements for <see cref="T:Krav.Argument"/>s of <see cref="T:System.Collections.IEnumerable"/>
    /// </summary>
    public static class EnumerableArgumentExtensions
    {
        /// <summary>
        ///   Requires that the <paramref name="argument"/> is not empty. Throws an exception if the
        ///   requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsNotEmpty<T>(this Argument<T> argument)
            where T : IEnumerable
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateNullException(argument, ExceptionMessages.Current.EmptyCollection);

            if (!argument.Value.GetEnumerator().MoveNext())
                throw ExceptionFactory.CreateArgumentException(argument, ExceptionMessages.Current.EmptyCollection);

            return argument;
        }

        /// <summary>
        ///   Requires that the <paramref name="argument"/> is not null and does not contain any null values.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> DoesNotContainNull<T>(this Argument<T> argument)
            where T : IEnumerable
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateNullException(argument, ExceptionMessages.Current.WasNull);

            var enumerator = argument.Value.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current == null)
                {
                    throw ExceptionFactory.CreateArgumentException(argument, ExceptionMessages.Current.ContainedNull);
                }
            }

            return argument;
        }
    }
}