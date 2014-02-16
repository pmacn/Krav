using System;
using System.Diagnostics;

namespace Krav
{
    /// <summary>
    ///   Requirements for <see cref="T:Krav.Argument"/>s of reference types
    /// </summary>
    public static class ClassArgumentExtensions
    {
        /// <summary>
        ///   Requires that the <paramref name="argument"/> is not null. Throws an exception if the
        ///   requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsNotNull<T>(this Argument<T> argument)
            where T : class
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateNullException(argument, ExceptionMessages.Current.WasNull);

            return argument;
        }
    }
}