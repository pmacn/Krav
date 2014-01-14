using System;

namespace RequireThat
{
    public static class StringExtensions
    {
        public static string Inject(this string format, params object[] args)
        {
            return String.Format(format, args);
        }

        public static string Inject(this string format, params string[] args)
        {
            return String.Format(format, args);
        }

        public static bool Any(this string source, Func<char, bool> predicate)
        {
            foreach (var c in source)
                if (predicate(c))
                    return true;

            return false;
        }
    }
}