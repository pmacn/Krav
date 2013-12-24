using RequireThat.Resources;
using System;
using System.Diagnostics;

namespace RequireThat
{
    public static class TypeArgumentExtensions
    {
        /// <summary>
        /// Requires that the <seealso cref="System.Type"/> <seealso cref="RequireThat.Argument"/> is type <typeparamref name="TExpected"/> or a derived type.
        /// Throws an exception if the requirement is not met.
        /// </summary>
        /// <remarks>
        /// This extension exists only because of <seealso cref="System.Windows.Data.IValueConverter"/>. There might be other valid use cases for it but I'm
        /// currently unaware of any.
        /// </remarks>
        /// <typeparam name="TExpected"></typeparam>
        /// <param name="argument">The <seealso cref="RequireThat.Argument"/> to add the requirement to.</param>
        /// <returns>The <seealso cref="RequireThat.Argument"/> that the extension was called on.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<Type> Is<TExpected>(this Argument<Type> argument)
        {
            var expectedType = typeof(TExpected);
            if (argument.Value == null)
                throw ExceptionFactory.CreateArgumentException(argument,
                    ExceptionMessages.IsNotExpectedType_WasNull.Inject(expectedType.FullName));

            if (!expectedType.IsAssignableFrom(argument.Value))
                throw ExceptionFactory.CreateArgumentException(argument,
                    ExceptionMessages.IsNotExpectedType.Inject(expectedType.FullName, argument.Value.FullName));

            return argument;
        }

        /// <summary>
        /// Requires that the <seealso cref="System.Type"/> <seealso cref="RequireThat.Argument"/> is type <typeparamref name="TExpected"/> or a derived type.
        /// Throws an exception if the requirement is not met.
        /// </summary>
        /// <remarks>
        /// This extension exists only because of <seealso cref="System.Windows.Data.IValueConverter"/>. There might be other valid use cases for it but I'm
        /// currently unaware of any.
        /// </remarks>
        /// <typeparam name="TExpected"></typeparam>
        /// <param name="argument">The <seealso cref="RequireThat.Argument"/> to add the requirement to.</param>
        /// <returns>The <seealso cref="RequireThat.Argument"/> that the extension was called on.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<Type> Is(this Argument<Type> argument, Type expectedType)
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateArgumentException(argument,
                    ExceptionMessages.IsNotExpectedType_WasNull.Inject(expectedType.FullName));

            if (!expectedType.IsAssignableFrom(argument.Value))
                throw ExceptionFactory.CreateArgumentException(argument,
                    ExceptionMessages.IsNotExpectedType.Inject(expectedType.FullName, argument.Value.FullName));

            return argument;
        }
    }
}