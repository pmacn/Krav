using System;

namespace RequireThat
{
    internal static class StringExtensions
    {
        internal static string Inject(this string format, params object[] args)
        {
            return String.Format(format, args);
        }

        internal static string Inject(this string format, params string[] args)
        {
            return String.Format(format, args);
        }
    }
}