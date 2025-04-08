namespace Krav
{
    using System;
    using System.Diagnostics;

    /// <summary>
    ///   An argument that can be verified to satisfy specific requirements.
    /// </summary>
    /// <typeparam name="T">The <see cref="T:System.Type"/> of the argument.</typeparam>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public sealed class Argument<T>(T value, string name)
    {
        /// <summary>
        /// Gets the value of the argument being validated.
        /// </summary>
        public T Value { get; } = value;

        /// <summary>
        /// Gets the name of the argument, used in exception messages.
        /// </summary>
        public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));

        /// <summary>
        ///   Requires that the argument is of type <typeparamref name="TExpected"/> or a derived type. Throws
        ///   an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="TExpected">The expected type.</typeparam>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public Argument<T> IsOfType<TExpected>()
        {
            return this.IsOfType(typeof(TExpected));
        }

        /// <summary>
        ///   Requires that the argument is of the <paramref name="expectedType"/> or a derived type.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <param name="expectedType">The expected type.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public Argument<T> IsOfType(Type expectedType)
        {
            Type actualType = this.Value == null ? typeof(T) : this.Value.GetType();

            if (!expectedType.IsAssignableFrom(actualType))
            {
                throw ExceptionFactory.CreateArgumentException(
                    this,
                    ExceptionMessages.Current.NotOfType.Inject(
                        expectedType.FullName ?? expectedType.Name,
                        actualType.FullName ?? actualType.Name));
            }

            return this;
        }
    }
}