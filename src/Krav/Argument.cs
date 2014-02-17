using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Krav.Resources;

namespace Krav
{
    /// <summary>
    ///   An argument that can be verified to satisfy specific requirements.
    /// </summary>
    /// <typeparam name="T">The <see cref="T:System.Type"/> of the argument</typeparam>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Argument<T>
    {
        internal readonly T Value;

        internal string Name { get { return name ?? (name = GetMemberName()); } }

        private readonly Func<T> function;

        private string name;

        internal Argument(string name, T value)
        {
            this.name = name;
            Value = value;
        }

        internal Argument(Func<T> function)
        {
            this.function = function;
            this.Value = function();
        }
        
        private string GetMemberName()
        {
            if (function == null)
                return String.Empty;

            var target = function.Target;
            if (target == null)
                return String.Empty;

            var targetType = target.GetType();

            // TODO: Need to check if there's a better way to assert that the target is a lambda closure class
            // or whatever they would be called.
            var attributes = targetType.GetCustomAttributes(typeof(CompilerGeneratedAttribute), false);
            if (attributes.Length == 0)
                return String.Empty;

            // HACK: since GetMethodBody is not available in PCL's this seems to be the best
            // bet at getting the name of the variable in the delegate.
            // This will of course fail horribly if the implementation of lambda closures
            // ever changes.
            var functionFields = target.GetType().GetFields();
            if (functionFields.Length == 1)
                return functionFields[0].Name;

            return String.Empty;
        }

        /// <summary>
        ///   Requires that the argument is of type <typeparamref name="TExpected"/> or a derived type. Throws
        ///   an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="TExpected">The expected type</typeparam>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public Argument<T> IsOfType<TExpected>()
        {
            return this.IsOfType(typeof(TExpected), null);
        }

        /// <summary>
        ///   Requires that the argument is of type <typeparamref name="TExpected"/> or a derived type. Throws
        ///   an exception with the specified <paramref name="message"/> if there requirement is not met.
        /// </summary>
        /// <typeparam name="TExpected">The expected type</typeparam>
        /// <param name="message">Exception message to use if the requirement is not met.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public Argument<T> IsOfType<TExpected>(string message)
        {
            return this.IsOfType(typeof(TExpected), message);
        }

        /// <summary>
        ///   Requires that the argument is of the <paramref name="expectedType"/> or a derived type.
        ///   Throws an exception if there requirement is not met.
        /// </summary>
        /// <param name="expectedType">The expected type.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public Argument<T> IsOfType(Type expectedType)
        {
            return IsOfType(expectedType, null);
        }

        /// <summary>
        ///   Requires that the argument is of the <paramref name="expectedType"/> or a derived type. Throws
        ///   an exception with the specified <paramref name="message"/> if there requirement is not met.
        /// </summary>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="message">Exception message to use if the requirement is not met.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public Argument<T> IsOfType(Type expectedType, string message)
        {
            var actualType = Value == null ? typeof(T) : Value.GetType();

            if (!expectedType.IsAssignableFrom(actualType))
                throw ExceptionFactory.CreateArgumentException(this, message ?? ExceptionMessages.NotOfType.Inject(expectedType.FullName, actualType.FullName));

            return this;
        }

        private string DebuggerDisplay
        {
            get
            {
                return String.Format("Argument<{0}>: Value: {1}; Name: {2}", typeof(T).Name, Value, Name);
            }
        }
    }
}