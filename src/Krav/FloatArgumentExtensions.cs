using System;
using System.Diagnostics;

namespace Krav
{
    /// <summary>
    ///   Requirements for <see cref="T:Krav.Argument&lt;float&gt;"/>
    /// </summary>
    public static class FloatArgumentExtensions
    {
        /// <summary>
        ///   Requires that the float argument is a valid number. An exception is thrown if the
        ///   requirement is not met.
        /// </summary>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<float> IsANumber(this Argument<float> argument)
        {
            if (Single.IsNaN(argument.Value))
                throw ExceptionFactory.CreateArgumentException(argument,
                    ExceptionMessages.Current.IsNotANumber);

            return argument;
        }
    }
}
