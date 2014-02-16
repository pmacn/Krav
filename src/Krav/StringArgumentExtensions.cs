using System;
using System.Diagnostics;

namespace Krav
{
    /// <summary>
    ///   Requirements for <see cref="T:Krav.Argument"/>s of <see cref="T:System.String"/>
    /// </summary>
    public static class StringArgumentExtensions
    {
        /// <summary>
        ///   Requires that the string <paramref name="argument"/> is not null or empty.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<string> IsNotNullOrEmpty(this Argument<string> argument)
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateNullException(argument, ExceptionMessages.Current.WasNullOrEmpty);

            if (argument.Value.Length == 0)
                throw ExceptionFactory.CreateArgumentException(argument, ExceptionMessages.Current.WasNullOrEmpty);

            return argument;
        }

        /// <summary>
        ///   Requires that the string <paramref name="argument"/> is not null, empty or only consisting
        ///   of white-space characters. Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<string> IsNotNullOrWhiteSpace(this Argument<string> argument)
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateNullException(argument, ExceptionMessages.Current.WasNullOrWhiteSpace);

            if (String.IsNullOrWhiteSpace(argument.Value))
                throw ExceptionFactory.CreateArgumentException(argument, ExceptionMessages.Current.WasNullOrWhiteSpace);

            return argument;
        }
    }
}
