using RequireThat.Resources;
using System;
using System.Collections;

namespace RequireThat
{
    public static class RequireThat
    {
        public static void ThisHolds(bool condition, string message)
        {
            if (!condition)
                throw new ArgumentException(message);
        }

        public static void NotNull<T>(T value, string name)
            where T : class
        {
            if (value == null)
                throw new ArgumentNullException(name, ExceptionMessages.WasNull);
        }

        public static void NotNull<T>(T? value, string name)
            where T : struct
        {
            if (value == null || !value.HasValue)
                throw new ArgumentNullException(name, ExceptionMessages.WasNull);
        }

        public static void NotNullOrEmpty(string value, string name)
        {
            NotNull(value, name);
            if (value.Length == 0)
                throw new ArgumentException(ExceptionMessages.WasNullOrEmpty, name);
        }

        public static void NotNullOrEmpty(IEnumerable value, string name)
        {
            NotNull(value, name);
            if (!value.GetEnumerator().MoveNext())
                throw new ArgumentException(ExceptionMessages.EmptyCollection, name);
        }

        public static void NotNullOrWhitespace(string value, string name)
        {
            NotNullOrEmpty(value, name);
            if (value.Any(Char.IsWhiteSpace))
                throw new ArgumentException(ExceptionMessages.WasNullOrWhiteSpace, name);
        }

        public static void IsNumber(double value, string name)
        {
            if (Double.IsNaN(value))
                throw new ArgumentException(ExceptionMessages.IsNotANumber, name);
        }

        public static void IsNumber(float value, string name)
        {
            if (Single.IsNaN(value))
                throw new ArgumentException(ExceptionMessages.IsNotANumber, name);
        }

        public static void IsOfType<T>(object value, string name)
        {
            IsOfType(value, name, typeof(T));
        }

        public static void IsOfType(object value, string name, Type expectedType)
        {
            var actualType = value.GetType();
            if (!expectedType.IsAssignableFrom(actualType))
                throw new ArgumentException(
                    ExceptionMessages.NotOfType.Inject(expectedType.FullName, actualType.FullName),
                    name);
        }
    }
}
