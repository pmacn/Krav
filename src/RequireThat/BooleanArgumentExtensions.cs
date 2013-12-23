using RequireThat.Resources;
using System.Diagnostics;

namespace RequireThat
{
    public static class BooleanArgumentExtensions
    {
        /// <summary>
        /// Requires that the <paramref name="argument"/> is true.
        /// Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="argument">The argument to add the requirement to.</argument>
        /// <returns>The <paramref name="argument" />.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<bool> IsTrue(this Argument<bool> argument)
        {
            return argument.IsTrue(ExceptionMessages.NotTrue);
        }
        
        /// <summary>
        /// Requires that the <paramref name="argument"/> is true.
        /// Throws an exception with the specified <paramref name="message"/> if the requirement is not met.
        /// </summary>
        /// <param name="argument">The <seealso cref="RequireThat.Argument" /> to add the requirement to.</param>
        /// <param name="message">Message to use in the <seealso cref="ArgumentException"/>.</param>
        /// <returns>The <paramref name="argument" />.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        public static Argument<bool> IsTrue(this Argument<bool> argument, string message)
        {
            if (!argument.Value)
                throw ExceptionFactory.CreateArgumentException(argument, message);

            return argument;
        }

        /// <summary>
        /// Requires that the <paramref name="argument"/> is false.
        /// Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="argument">The <seealso cref="RequireThat.Argument" /> to add the requirement to.</param>
        /// <returns>The <paramref name="argument" />.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<bool> IsFalse(this Argument<bool> argument)
        {
            return argument.IsFalse(ExceptionMessages.NotFalse);
        }

        /// <summary>
        /// Requires that the <paramref name="argument"/> is false.
        /// Throws an exception with the specified <paramref name="message"/> if the requirement is not met.
        /// </summary>
        /// <param name="argument">The <seealso cref="RequireThat.Argument" /> to add the requirement to.</param>
        /// <param name="message">Message to use in the <seealso cref="ArgumentException"/>.</param>
        /// <returns>The <paramref name="argument" />.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        public static Argument<bool> IsFalse(this Argument<bool> argument, string message)
        {
            if (argument.Value)
                throw ExceptionFactory.CreateArgumentException(argument, message);

            return argument;
        }
    }
}