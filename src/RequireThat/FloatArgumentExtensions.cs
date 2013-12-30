using RequireThat.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace RequireThat
{
    public static class FloatArgumentExtensions
    {
        /// <summary>
        /// Requires that the float argument is a valid number.
        /// An exception is thrown if the requirement is not met.
        /// </summary>
        /// <param name="argument"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static Argument<float> IsANumber(this Argument<float> argument)
        {
            if (Single.IsNaN(argument.Value))
                throw ExceptionFactory.CreateArgumentException(argument,
                    ExceptionMessages.IsNotANumber);

            return argument;
        }
    }
}
