using RequireThat.Resources;
using System.Diagnostics;

namespace RequireThat
{
    public static class NullableArgumentExtensions
    {
        /// <summary>
        ///   Requires that the <paramref name="argument"/> is not null.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">
        ///   The <seealso cref="RequireThat.Argument"/> to add the requirement to.
        /// </param>
        /// <returns>
        ///   The <seealso cref="RequireThat.Argument"/> that the extension was called on.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T?> IsNotNull<T>(this Argument<T?> argument)
            where T : struct
        {
            if (argument.Value == null || !argument.Value.HasValue)
                throw ExceptionFactory.CreateNullException(argument, ExceptionMessages.WasNull);

            return argument;
        }
    }
}