using RequireThat.Resources;
using System;
using System.Diagnostics;

namespace RequireThat
{
    public static class GuidArgumentExtensions
    {
        /// <summary>
        /// Requires that the <paramref name="argument"/> is not the Empty Guid.
        /// Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="argument">The <seealso cref="RequireThat.Argument"/> to add the requirement to.</param>
        /// <returns>The <seealso cref="RequireThat.Argument"/> that the extension was called on.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<Guid> IsNotEmpty(this Argument<Guid> argument)
        {
            return argument.IsNotEmpty(ExceptionMessages.EmptyGuid);
        }

        [DebuggerStepThrough]
        public static Argument<Guid> IsNotEmpty(this Argument<Guid> argument, string message)
        {
            if (Guid.Empty.Equals(argument.Value))
                throw ExceptionFactory.CreateArgumentException(argument, message);

            return argument;
        }
    }
}