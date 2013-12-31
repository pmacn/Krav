using RequireThat.Resources;
using System;
using System.Diagnostics;

namespace RequireThat
{
    public static class ComparableArgumentExtensions
    {
        /// <summary>
        ///   Requires that the <paramref name="argument"/> is less than <paramref name="limit"/>.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">
        ///   The <seealso cref="RequireThat.Argument"/> to add the requirement to.
        /// </param>
        /// <param name="limit">
        ///   The limit that the <paramref name="argument"/> must be less than.
        /// </param>
        /// <returns>
        ///   The <seealso cref="RequireThat.Argument"/> that the extension was called on.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThan<T>(this Argument<T> argument, object limit)
            where T : IComparable
        {
            return IsLessThanImpl(argument, limit);
        }
  
        /// <summary>
        ///   Requires that the <paramref name="argument"/> is less than <paramref name="limit"/>.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">
        ///   The <seealso cref="RequireThat.Argument"/> to add the requirement to.
        /// </param>
        /// <param name="limit">
        ///   The limit that the <paramref name="argument"/> must be less than.
        /// </param>
        /// <returns>
        ///   The <seealso cref="RequireThat.Argument"/> that the extension was called on.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThan<T>(this Argument<T> argument, T limit)
            where T : IComparable<T>
        {
            return IsLessThanImpl(argument, limit);
        }

        private static Argument<T> IsLessThanImpl<T>(Argument<T> argument, object limit)
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateNullException(argument,
                    ExceptionMessages.NotLessThan_WasNull.Inject(limit));

            if (argument.CompareValueTo(limit) >= 0)
                throw ExceptionFactory.CreateArgumentException(argument,
                ExceptionMessages.NotLessThan.Inject(limit, argument.Value));

            return argument;
        }

        /// <summary>
        ///   Requires that the <paramref name="argument"/> is less than or equal to <paramref name="limit"/>
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">
        ///   The <seealso cref="RequireThat.Argument"/> to add the requirement to.
        /// </param>
        /// <param name="limit">
        ///   The limit that the <paramref name="argument"/> must be less than or equal to.
        /// </param>
        /// <returns>
        ///   The <seealso cref="RequireThat.Argument"/> that the extension was called on.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThanOrEqualTo<T>(this Argument<T> argument, object limit)
            where T : IComparable
        {
            return IsLessThanOrEqualToImpl(argument, limit);
        }

        /// <summary>
        ///   Requires that the <paramref name="argument"/> is less than or equal to <paramref name="limit"/>.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">
        ///   The <seealso cref="RequireThat.Argument"/> to add the requirement to.
        /// </param>
        /// <param name="limit">
        ///   The limit that the <paramref name="argument"/> must be less than or equal to.
        /// </param>
        /// <returns>
        ///   The <seealso cref="RequireThat.Argument"/> that the extension was called on.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThanOrEqualTo<T>(this Argument<T> argument, T limit)
            where T : IComparable<T>
        {
            return IsLessThanOrEqualToImpl(argument, limit);
        }

        private static Argument<T> IsLessThanOrEqualToImpl<T>(Argument<T> argument, object limit)
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateNullException(argument,
                    ExceptionMessages.NotLessThanOrEqualTo_WasNull.Inject(limit));

            if (argument.CompareValueTo(limit) > 0)
                throw ExceptionFactory.CreateArgumentException(argument,
                    ExceptionMessages.NotLessThanOrEqualTo.Inject(limit, argument.Value));

            return argument;
        }

        /// <summary>
        ///   Requires that the <paramref name="argument"/> is greater than <paramref name="limit"/>.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">
        ///   The <seealso cref="RequireThat.Argument"/> to add the requirement to.
        /// </param>
        /// <param name="limit">
        ///   The limit that the <paramref name="argument"/> must be greater than.
        /// </param>
        /// <returns>
        ///   The <seealso cref="RequireThat.Argument"/> that the extension was called on.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThan<T>(this Argument<T> argument, object limit)
            where T : IComparable
        {
            return IsGreaterThanImpl(argument, limit);
        }

        /// <summary>
        ///   Requires that the <paramref name="argument"/> is greater than <paramref name="limit"/>.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">
        ///   The <seealso cref="RequireThat.Argument"/> to add the requirement to.
        /// </param>
        /// <param name="limit">
        ///   The limit that the <paramref name="argument"/> must be greater than.
        /// </param>
        /// <returns>
        ///   The <seealso cref="RequireThat.Argument"/> that the extension was called on.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThan<T>(this Argument<T> argument, T limit)
            where T : IComparable<T>
        {
            return IsGreaterThanImpl(argument, limit);
        }

        public static Argument<T> IsGreaterThanImpl<T>(Argument<T> argument, object limit)
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateNullException(argument,
                    ExceptionMessages.NotGreaterThan_WasNull.Inject(limit));

            if (argument.CompareValueTo(limit) <= 0)
                throw ExceptionFactory.CreateArgumentException(argument,
                    ExceptionMessages.NotGreaterThan.Inject(limit, argument.Value));

            return argument;
        }

        /// <summary>
        /// Requires that the <paramref name="argument"/> is greater than or equal to <paramref name="limit"/>.
        /// Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">
        ///   The <seealso cref="RequireThat.Argument"/> to add the requirement to.
        /// </param>
        /// <param name="limit">
        ///   The limit that the <paramref name="argument"/> must be greater than or equal to.
        /// </param>
        /// <returns>
        ///   The <seealso cref="RequireThat.Argument"/> that the extension was called on.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThanOrEqualTo<T>(this Argument<T> argument, object limit)
            where T : IComparable
        {
            return IsGreaterThanOrEqualToImpl(argument, limit);
        }

        /// <summary>
        /// Requires that the <paramref name="argument"/> is greater than or equal to <paramref name="limit"/>.
        /// Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <seealso cref="RequireThat.Argument"/> to add the requirement to.</param>
        /// <param name="limit">The limit that the <paramref name="argument"/> must be greater than or equal to.</param>
        /// <returns>The <seealso cref="RequireThat.Argument"/> that the extension was called on.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThanOrEqualTo<T>(this Argument<T> argument, T limit)
            where T : IComparable<T>
        {
            return IsGreaterThanOrEqualToImpl(argument, limit);
        }

        private static Argument<T> IsGreaterThanOrEqualToImpl<T>(Argument<T> argument, object limit)
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateNullException(argument,
                    ExceptionMessages.NotGreaterThanOrEqualTo_WasNull.Inject(limit));

            if (argument.CompareValueTo(limit) < 0)
                throw ExceptionFactory.CreateArgumentException(argument,
                    ExceptionMessages.NotGreaterThanOrEqualTo.Inject(limit, argument.Value));

            return argument;
        }

        /// <summary>
        /// Requires that the <paramref name="argument"/> falls with in the range specified by <paramref name="min"/> and <paramref name="max"/>, inclusive.
        /// Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <seealso cref="RequireThat.Argument"/> to add the requirement to.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range</param>
        /// <returns>The <seealso cref="RequireThat.Argument"/> that the extension was called on.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsInRange<T>(this Argument<T> argument, object min, object max)
            where T: IComparable
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateNullException(argument,
                    ExceptionMessages.NotInRange_WasNull.Inject(min, max));

            if (argument.CompareValueTo(min) < 0)
                throw ExceptionFactory.CreateArgumentException(argument,
                    ExceptionMessages.NotInRange_TooLow.Inject(min, max));

            if (argument.CompareValueTo(max) > 0)
                throw ExceptionFactory.CreateArgumentException(argument,
                    ExceptionMessages.NotInRange_TooHigh.Inject(min, max));

            return argument;
        }

        /// <summary>
        /// Requires that the <paramref name="argument"/> falls with in the range specified by <paramref name="min"/> and <paramref name="max"/>, inclusive.
        /// Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <seealso cref="RequireThat.Argument"/> to add the requirement to.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range</param>
        /// <returns>The <seealso cref="RequireThat.Argument"/> that the extension was called on.</returns>
        /// <exception cref="ArgumentException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsInRange<T>(this Argument<T> argument, T min, T max)
            where T : IComparable<T>
        {
            if (argument.Value == null)
                throw ExceptionFactory.CreateNullException(argument,
                    ExceptionMessages.NotInRange_WasNull.Inject(min, max));

            if (argument.CompareValueTo(min) < 0)
                throw ExceptionFactory.CreateArgumentException(argument,
                    ExceptionMessages.NotInRange_TooLow.Inject(min, max));

            if (argument.CompareValueTo(max) > 0)
                throw ExceptionFactory.CreateArgumentException(argument,
                    ExceptionMessages.NotInRange_TooHigh.Inject(min, max));

            return argument;
        }

        private static int CompareValueTo<T>(this Argument<T> argument, object comparisonValue)
        {
            try
            {
                if (argument.Value is IComparable<T> && comparisonValue is T)
                    return (argument.Value as IComparable<T>).CompareTo((T)comparisonValue);

                if (argument.Value is IComparable)
                    return (argument.Value as IComparable).CompareTo(comparisonValue);
            }
            catch (ArgumentException)
            {
                throw ExceptionFactory.CreateArgumentException(
                    argument,
                    ExceptionMessages.IncomparableTypes.Inject(
                        argument.GetType().FullName,
                        comparisonValue.GetType().FullName));
            }

            throw new InvalidOperationException("This should not be possible, please report an issue at http://github.com/pmacn/Require.That with the code used get this exception.");
        }
    }
}
