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
        public static Argument<Guid> IsNotEmpty(this Argument<Guid> statement)
        {
            if (Guid.Empty.Equals(statement.Value))
                throw ExceptionFactory.CreateArgumentException(statement, ExceptionMessages.EmptyGuid);

            return statement;
        }
    }
}