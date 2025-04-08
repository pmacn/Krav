namespace Krav
{
    using System;
    using System.Collections;

    /// <summary>
    ///   A set of requirement methods to use when verifying that arguments meet specific requirements.
    /// </summary>
    public static class RequireThat
    {
        /// <summary>
        ///   Requires that <paramref name="condition"/> is true. Throws an exception if the requirement fails.
        /// </summary>
        /// <param name="condition">The condition to verify.</param>
        /// <param name="message">Exception message to use if the requirement fails.</param>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        public static void ThisHolds(bool condition, string message)
        {
            if (!condition)
            {
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        ///   Requires that <paramref name="value"/> is not null. Throws an exception if the requirement fails.
        /// </summary>
        /// <typeparam name="T">The <see cref="T:System.Type"/> of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value to verify.</param>
        /// <param name="name">The name of the value.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
        public static void NotNull<T>(T value, string name)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(name, ExceptionMessages.Current.WasNull);
            }
        }

        /// <summary>
        ///   Requires that <paramref name="value"/> value is not null and that it has a value. Throws an
        ///   exception if the requirement fails.
        /// </summary>
        /// <typeparam name="T">The <see cref="T:System.Type"/> of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value to verify.</param>
        /// <param name="name">The name of the value.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
        public static void NotNull<T>(T? value, string name)
            where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException(name, ExceptionMessages.Current.WasNull);
            }
        }

        /// <summary>
        ///   Requires that <paramref name="value"/> is not null or an empty <see cref="T:System.String"/>.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="value">The value to verify.</param>
        /// <param name="name">The name of the value.</param>
        /// <exception cref="T:System.ArgumentException">Thrown if <paramref name="value"/> is empty.</exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
        public static void NotNullOrEmpty(string value, string name)
        {
            NotNull(value, name);
            if (value.Length == 0)
            {
                throw new ArgumentException(ExceptionMessages.Current.WasEmptyString, name);
            }
        }

        /// <summary>
        ///   Requires that <paramref name="value"/> is not null or an empty <see cref="T:System.Collections.IEnumerable"/>.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="value">The value to verify.</param>
        /// <param name="name">The name of the value.</param>
        /// <exception cref="T:System.ArgumentException">Thrown if <paramref name="value"/> is empty.</exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
        public static void NotNullOrEmpty(IEnumerable value, string name)
        {
            NotNull(value, name);
            if (!value.GetEnumerator().MoveNext())
            {
                throw new ArgumentException(ExceptionMessages.Current.EmptyCollection, name);
            }
        }

        /// <summary>
        ///   Requires that <paramref name="value"/> is not null and contains no null values.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="value">The value to verify.</param>
        /// <param name="name">The name of the value.</param>
        /// <exception cref="T:System.ArgumentException">Thrown if <paramref name="value"/> is empty.</exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
        public static void DoesNotContainNull(IEnumerable value, string name)
        {
            NotNull(value, name);
            var enumerator = value.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current == null)
                {
                    throw new ArgumentException(ExceptionMessages.Current.ContainedNull, name);
                }
            }
        }

        /// <summary>
        ///   Requires that <paramref name="value"/> is not null, empty or only consisting of white-space
        ///   characters.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="value">The value to verify.</param>
        /// <param name="name">The name of the value.</param>
        /// <exception cref="T:System.ArgumentException">Thrown if <paramref name="value"/> is empty or white-space.</exception>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
        public static void NotNullOrWhitespace(string value, string name)
        {
            NotNullOrEmpty(value, name);
            if (value.Any(char.IsWhiteSpace))
            {
                throw new ArgumentException(ExceptionMessages.Current.WasWhiteSpace, name);
            }
        }

        /// <summary>
        ///   Requires that <paramref name="value"/> is a number.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="value">The value to verify.</param>
        /// <param name="name">The name of the value.</param>
        /// <exception cref="T:System.ArgumentException">Thrown if <paramref name="value"/> is not a number.</exception>
        public static void IsNumber(double value, string name)
        {
            if (double.IsNaN(value))
            {
                throw new ArgumentException(ExceptionMessages.Current.IsNotANumber, name);
            }
        }
        
        /// <summary>
        ///   Requires that <paramref name="value"/> is a number.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="value">The value to verify.</param>
        /// <param name="name">The name of the value.</param>
        /// <exception cref="T:System.ArgumentException">Thrown if <paramref name="value"/> is not a number.</exception>
        public static void IsNumber(float value, string name)
        {
            if (float.IsNaN(value))
            {
                throw new ArgumentException(ExceptionMessages.Current.IsNotANumber, name);
            }
        }

        /// <summary>
        ///   Requires that <paramref name="value"/> is of the specified <see cref="T:System.Type"/>.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type that <paramref name="value"/> is required to be of.</typeparam>
        /// <param name="value">The value to verify.</param>
        /// <param name="name">The name of the value.</param>
        /// <exception cref="T:System.ArgumentException">Thrown if <paramref name="value"/> is not of the specified type.</exception>
        public static void IsOfType<T>(object value, string name)
        {
            IsOfType(value, name, typeof(T));
        }

        /// <summary>
        ///   Requires that <paramref name="value"/> is of the specified type.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="value">The value to verify.</param>
        /// <param name="name">The name of the value.</param>
        /// <param name="expectedType">The type that <paramref name="value"/> is required to be of.</param>
        /// <exception cref="T:System.ArgumentException">Thrown if <paramref name="value"/> is not of the specified type.</exception>
        public static void IsOfType(object value, string name, Type expectedType)
        {
            var actualType = value.GetType();
            if (!expectedType.IsAssignableFrom(actualType))
            {
                throw new ArgumentException(
                    ExceptionMessages.Current.NotOfType.Inject(expectedType.FullName ?? expectedType.Name, actualType.FullName ?? actualType.Name),
                    name);
            }
        }
    }
}
