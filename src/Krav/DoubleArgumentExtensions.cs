﻿namespace Krav
{
    using System.Diagnostics;
    using static Double;

    /// <summary>
    ///   Requirements for <see cref="T:Krav.Argument"/>s of <see cref="T:System.Double"/>.
    /// </summary>
    public static class DoubleArgumentExtensions
    {
        /// <summary>
        ///   Requires that the double argument is a valid number. An exception is thrown if the
        ///   requirement is not met.
        /// </summary>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<double> IsANumber(this Argument<double> argument)
        {
            if (IsNaN(argument.Value))
            {
                throw ExceptionFactory.CreateArgumentException(
                    argument,
                    ExceptionMessages.Current.IsNotANumber);
            }

            return argument;
        }
    }
}
