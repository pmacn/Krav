using System;
using System.Diagnostics;
using Krav.Resources;

namespace Krav
{
    /// <summary>
    ///   Requirements for <see cref="T:Krav.Argument"/>s of <see cref="T:System.Guid"/>
    /// </summary>
    public static class GuidArgumentExtensions
    {
        /// <summary>
        ///   Requires that the <paramref name="argument"/> is not the Empty Guid. Throws an exception
        ///   if the requirement is not met.
        /// </summary>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<Guid> IsNotEmpty(this Argument<Guid> argument)
        {
            return argument.IsNotEmpty(ExceptionMessages.EmptyGuid);
        }

        /// <summary>
        ///   Requires that the <paramref name="argument"/> is not the Empty Guid. Throws an exception
        ///   with the specified <paramref name="message"/> if the requirement is not met.
        /// </summary>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <param name="message">Exception message to use if the requirement fails.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<Guid> IsNotEmpty(this Argument<Guid> argument, string message)
        {
            if (Guid.Empty.Equals(argument.Value))
                throw ExceptionFactory.CreateArgumentException(argument, message);

            return argument;
        }
    }
}