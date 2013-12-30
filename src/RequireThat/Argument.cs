using RequireThat.Resources;
using System;
using System.Diagnostics;

namespace RequireThat
{
    public class Argument<T>
    {
        internal readonly T Value;

        internal readonly string Name;

        internal Argument(string name, T value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Requires that the argument is of type <typeparamref name="T"/> or a derived type.
        /// Throws an exception if there requirement is not met.
        /// </summary>
        /// <typeparam name="TExpected">The expected type</typeparam>
        /// <returns>The calling <paramref name="RequireThat.Argument"/></returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public Argument<T> IsOfType<TExpected>()
        {
            return this.IsOfType(typeof(TExpected), null);
        }

        /// <summary>
        /// Requires that the argument is of type <typeparamref name="T"/> or a derived type.
        /// Throws an exception if there requirement is not met.
        /// </summary>
        /// <typeparam name="TExpected">The expected type</typeparam>
        /// <returns>The calling <paramref name="RequireThat.Argument"/></returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public Argument<T> IsOfType<TExpected>(string message)
        {
            return this.IsOfType(typeof(TExpected), message);
        }

        /// <summary>
        /// Requires that the argument is of the <paramref name="expectedType"/> or a derived type.
        /// Throws an exception if there requirement is not met.
        /// </summary>
        /// <param name="expectedType">The expected type.</param>
        /// <returns>The calling <paramref name="RequireThat.Argument"/></returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public Argument<T> IsOfType(Type expectedType)
        {
            return IsOfType(expectedType, null);
        }

        /// <summary>
        /// Requires that the argument is of the <paramref name="expectedType"/> or a derived type.
        /// Throws an exception if there requirement is not met.
        /// </summary>
        /// <param name="expectedType">The expected type.</param>
        /// <returns>The calling <paramref name="RequireThat.Argument"/></returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public Argument<T> IsOfType(Type expectedType, string message)
        {
            var actualType = Value == null ? typeof(T) : Value.GetType();

            if (!expectedType.IsAssignableFrom(actualType))
                throw ExceptionFactory.CreateArgumentException(this, message ?? ExceptionMessages.NotOfType.Inject(expectedType.FullName, actualType.FullName));

            return this;
        }
    }
}