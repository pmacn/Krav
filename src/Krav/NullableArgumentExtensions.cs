using System.Diagnostics;
using Krav.Resources;

namespace Krav
{
    /// <summary>
    ///   Requirements for <see cref="T:Krav.Argument&lt;System.Nullable&gt;"/>
    /// </summary>
    public static class NullableArgumentExtensions
    {
        /// <summary>
        ///   Requires that the <paramref name="argument"/> is not null.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the requirement is not met.</exception>
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