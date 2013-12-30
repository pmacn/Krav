using RequireThat.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace RequireThat
{
    public static class DoubleArgumentExtensions
    {
        /// <summary>
        /// Requires that the double argument is a valid number.
        /// An exception is thrown if the requirement is not met.
        /// </summary>
        /// <param name="argument"></param>
        /// <returns></returns>
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
