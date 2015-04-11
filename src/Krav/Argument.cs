namespace Krav
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///   An argument that can be verified to satisfy specific requirements.
    /// </summary>
    /// <typeparam name="T">The <see cref="T:System.Type"/> of the argument</typeparam>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Argument<T>
    {
        internal readonly T Value;

        private readonly Func<T> function;

        private string name;

        internal Argument(string name, T value)
        {
            this.name = name;
            this.Value = value;
        }

        internal Argument(Func<T> function)
        {
            this.function = function;
            this.Value = function();
        }

        internal string Name
        {
            get
            {
                return this.name ?? (this.name = this.GetMemberName());
            }
        }

        private string DebuggerDisplay
        {
            get
            {
                return string.Format("Argument<{0}>: Value: {1}; Name: {2}", typeof(T).Name, this.Value, this.Name);
            }
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
            return this.IsOfType(typeof(TExpected));
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
            var actualType = this.Value == null ? typeof(T) : this.Value.GetType();

            if (!expectedType.IsAssignableFrom(actualType))
            {
                throw ExceptionFactory.CreateArgumentException(
                    this,
                    ExceptionMessages.Current.NotOfType.Inject(expectedType.FullName, actualType.FullName));
            }

            return this;
        }

        private string GetMemberName()
        {
            if (this.function == null)
            {
                return string.Empty;
            }

            var target = this.function.Target;
            if (target == null)
            {
                return string.Empty;
            }

            var targetType = target.GetType();

            // TODO: Need to check if there's a better way to assert that the target is a lambda closure class
            // or whatever they would be called.
            var attributes = targetType.GetCustomAttributes(typeof(CompilerGeneratedAttribute), false);
            if (attributes.Length == 0)
            {
                return string.Empty;
            }

            // HACK: since GetMethodBody is not available in PCL's this seems to be the best
            // bet at getting the name of the variable in the delegate.
            // This will of course fail horribly if the implementation of lambda closures
            // ever changes.
            var functionFields = target.GetType().GetFields();
            return functionFields.Length == 1 ? functionFields[0].Name : string.Empty;
        }
    }
}