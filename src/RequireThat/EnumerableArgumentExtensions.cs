using RequireThat.Resources;
using System.Collections;
using System.Diagnostics;

namespace RequireThat
{
    public static class EnumerableArgumentExtensions
    {
        /// <summary>
        /// Requires that the <paramref name="argument"/> is not empty.
        /// Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <seealso cref="RequireThat.Argument"/> to add the requirement to.</param>
        /// <returns>The <seealso cref="RequireThat.Argument"/> that the extension was called on.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsNotEmpty<T>(this Argument<T> argument)
            where T : IEnumerable
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateArgumentException(argument, ExceptionMessages.EmptyCollection);

            if(!argument.Value.GetEnumerator().MoveNext()) // poor-mans .Any()
                throw ExceptionFactory.CreateArgumentException(argument, ExceptionMessages.EmptyCollection);
            
            return argument;
        }
    }
}