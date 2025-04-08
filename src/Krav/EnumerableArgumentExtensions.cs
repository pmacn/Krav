namespace Krav
{
    using System.Collections;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    ///   Requirements for <see cref="T:Krav.Argument"/>s of <see cref="T:System.Collections.IEnumerable"/>.
    /// </summary>
    public static class EnumerableArgumentExtensions
    {
        /// <summary>
        ///   Requires that the <paramref name="argument"/> is not empty.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:Krav.Argument{T}"/> to verify.</param>
        /// <returns>The verified <see cref="T:Krav.Argument{T}"/>.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown if the argument value is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentException">Thrown if the argument is an empty collection.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsNotEmpty<T>(this Argument<T> argument)
            where T : IEnumerable
        {
            if (argument.Value == null)
            {
                throw ExceptionFactory.CreateNullException(argument);
            }

            if (!argument.Value.GetEnumerator().MoveNext())
            {
                throw ExceptionFactory.CreateArgumentException(argument, ExceptionMessages.Current.EmptyCollection);
            }

            return argument;
        }

        /// <summary>
        ///   Requires that the <paramref name="argument"/> is not null and does not contain any <c>null</c> elements.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:Krav.Argument{T}"/> to verify.</param>
        /// <returns>The verified <see cref="T:Krav.Argument{T}"/>.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown if the argument value is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentException">Thrown if the argument contains <c>null</c> elements.</exception>
        [DebuggerStepThrough]
        public static Argument<T> DoesNotContainNull<T>(this Argument<T> argument)
            where T : IEnumerable
        {
            if (argument.Value == null)
            {
                throw ExceptionFactory.CreateNullException(argument);
            }

            if (argument.Value.Cast<object>().Any(o => o == null))
            {
                throw ExceptionFactory.CreateArgumentException(argument, ExceptionMessages.Current.ContainedNull);
            }

            return argument;
        }
    }
}