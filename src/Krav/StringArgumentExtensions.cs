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
            return argument.IsNotNullOrEmpty(ExceptionMessages.Current.WasNullOrEmpty);
        }

        /// <summary>
        ///   Requires that the string <paramref name="argument"/> is not null or empty. Throws an
        ///   exception with the specified <paramref name="message"/> if the requirement is not met.
        /// </summary>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <param name="message">Exception message to use if the requirement fails.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<string> IsNotNullOrEmpty(this Argument<string> argument, string message)
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateNullException(argument, message);

            if (argument.Value.Length == 0)
                throw ExceptionFactory.CreateArgumentException(argument, message);

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
            return argument.IsNotNullOrWhiteSpace(ExceptionMessages.Current.WasNullOrWhiteSpace);
        }

        /// <summary>
        ///   Requires that the string <paramref name="argument"/> is not null, empty or only consisting
        ///   of white-space characters. Throws an exception with the specified <paramref name="message"/>
        ///   if the requirement is not met.
        /// </summary>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <param name="message">Exception message to use if the requirement fails.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<string> IsNotNullOrWhiteSpace(this Argument<string> argument, string message)
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateNullException(argument, message);

            if (String.IsNullOrWhiteSpace(argument.Value))
                throw ExceptionFactory.CreateArgumentException(argument, message);

            return argument;
        }
    }
}
