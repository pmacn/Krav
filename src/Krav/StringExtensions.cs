namespace Krav
{
    using System;
    using System.Linq;

    /// <summary>
    ///   Extension methods for <see cref="T:System.String"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///   Injects the provided arguments into the string using <see cref="M:System.String.Format"/> rules.
        /// </summary>
        /// <param name="format">The string to inject arguments into</param>
        /// <param name="args">The arguments to inject.</param>
        /// <returns>The resulting <see cref="T:System.String"/> after injecting the arguments.</returns>
        public static string Inject(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        ///   Implementation of Any for strings
        /// </summary>
        /// <param name="source">The string</param>
        /// <param name="predicate">The predicate</param>
        /// <returns>true if any of the characters in the string satisfies the predicate; otherwise false</returns>
        public static bool Any(this string source, Func<char, bool> predicate)
        {
            return source.Cast<char>().Any(predicate);
        }
    }
}