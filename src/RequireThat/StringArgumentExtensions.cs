using RequireThat.Resources;
using System;
using System.Diagnostics;

namespace RequireThat
{
    public static class StringArgumentExtensions
    {
        /// <summary>
        /// Requires that the string <paramref name="argument"/> is not null or empty.
        /// Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="argument">The <seealso cref="RequireThat.Argument"/> to add the requirement to.</param>
        /// <returns>The <seealso cref="RequireThat.Argument"/> that the extension was called on.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<string> IsNotNullOrEmpty(this Argument<string> argument)
        {
            if(String.IsNullOrEmpty(argument.Value))
                throw ExceptionFactory.CreateArgumentException(argument, ExceptionMessages.WasNullOrEmpty);

            return argument;
        }

        /// <summary>
        /// Requires that the string <paramref name="argument"/> is not null, empty or only consisting of white-space characters.
        /// Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="argument">The <seealso cref="RequireThat.Argument"/> to add the requirement to.</param>
        /// <returns>The <seealso cref="RequireThat.Argument"/> that the extension was called on.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<string> IsNotNullOrWhiteSpace(this Argument<string> argument)
        {
            if (string.IsNullOrWhiteSpace(argument.Value))
                throw ExceptionFactory.CreateArgumentException(argument, ExceptionMessages.WasNullOrWhiteSpace);

            return argument;
        }
    }
}
