using RequireThat.Resources;
using System;
using System.Diagnostics;

namespace RequireThat
{
    /// <summary>
    ///   Requirements for <see cref="T:RequireThat.Argument"/>s of <see cref="T:System.Double"/>
    /// </summary>
    public static class DoubleArgumentExtensions
    {
        /// <summary>
        ///   Requires that the double argument is a valid number. An exception is thrown if the
        ///   requirement is not met.
        /// </summary>
        /// <param name="argument">The <see cref="T:RequireThat.Argument"/> to verify.</param>
        /// <returns>The verified <see cref="T:RequireThat.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<double> IsANumber(this Argument<double> argument)
        {
            if (Double.IsNaN(argument.Value))
                throw ExceptionFactory.CreateArgumentException(argument,
                    ExceptionMessages.IsNotANumber);

            return argument;
        }
    }
}
