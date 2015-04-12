namespace Krav
{
    using System;
    using System.Diagnostics;

    /// <summary>
    ///   Extensions for <see cref="T:Krav.Argument"/>s of <see cref="T:System.Type"/>
    /// </summary>
    public static class TypeArgumentExtensions
    {
        /// <summary>
        ///   Requires that the <see cref="System.Type"/> <see cref="T:Krav.Argument"/> is of type
        ///   <typeparamref name="TExpected"/> or a derived type. Throws an exception if the requirement is
        ///   not met.
        /// </summary>
        /// <remarks>
        ///   This extension exists only because of <see cref="T:System.Windows.Data.IValueConverter"/>.
        ///   There might be other valid use cases for it but I'm currently unaware of any.
        /// </remarks>
        /// <typeparam name="TExpected"></typeparam>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<Type> Is<TExpected>(this Argument<Type> argument)
        {
            return argument.Is(typeof(TExpected));
        }

        /// <summary>
        ///   Requires that the <see cref="System.Type"/> <see cref="T:Krav.Argument"/>
        ///   is of type <paramref name="expectedType" /> or a derived type. Throws an exception if the
        ///   requirement is not met.
        /// </summary>
        /// <remarks>
        ///   This extension exists only because of <see cref="T:System.Windows.Data.IValueConverter"/>.
        ///   There might be other valid use cases for it but I'm currently unaware of any.
        /// </remarks>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <param name="expectedType">
        ///   The <see cref="T:System.Type"/> that the <paramref name="argument"/> needs to be of.
        /// </param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<Type> Is(this Argument<Type> argument, Type expectedType)
        {
            if (argument.Value == null)
            {
                throw ExceptionFactory.CreateNullException(argument);
            }

            if (!expectedType.IsAssignableFrom(argument.Value))
            {
                throw ExceptionFactory.CreateArgumentException(
                    argument,
                    ExceptionMessages.Current.IsNotExpectedType.Inject(expectedType.FullName, argument.Value.FullName));
            }

            return argument;
        }
    }
}