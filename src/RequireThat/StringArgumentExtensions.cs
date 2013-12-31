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
            return argument.IsNotNullOrEmpty(ExceptionMessages.WasNullOrEmpty);
        }

        /// <summary>
        /// Requires that the string <paramref name="argument"/> is not null or empty.
        /// Throws an exception with the specified <paramref name="message"/> if the requirement is not met.
        /// </summary>
        /// <param name="argument">The <seealso cref="RequireThat.Argument"/> to add the requirement to.</param>
        /// <param name="message">Message to use in the <seealso cref="ArgumentException"/>.</param>
        /// <returns>The <seealso cref="RequireThat.Argument"/> that the extension was called on.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
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
        /// Requires that the string <paramref name="argument"/> is not null, empty or only consisting of white-space characters.
        /// Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="argument">The <seealso cref="RequireThat.Argument"/> to add the requirement to.</param>
        /// <returns>The <seealso cref="RequireThat.Argument"/> that the extension was called on.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<string> IsNotNullOrWhiteSpace(this Argument<string> argument)
        {
            return argument.IsNotNullOrWhiteSpace(ExceptionMessages.WasNullOrWhiteSpace);
        }

        /// <summary>
        /// Requires that the string <paramref name="argument"/> is not null, empty or only consisting of white-space characters.
        /// Throws an exception with the specified <paramref name="message"/> if the requirement is not met.
        /// </summary>
        /// <param name="argument">The <seealso cref="RequireThat.Argument"/> to add the requirement to.</param>
        /// <param name="message">Message to use in the <seealso cref="ArgumentException"/>.</param>
        /// <returns>The <seealso cref="RequireThat.Argument"/> that the extension was called on.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
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
