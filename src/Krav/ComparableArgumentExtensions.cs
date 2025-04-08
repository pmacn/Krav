namespace Krav
{
    using System;
    using System.Diagnostics;

    /// <summary>
    ///   Requirements for <see cref="T:Krav.Argument"/>s of <see cref="T:System.IComparable"/>
    /// </summary>
    public static class ComparableArgumentExtensions
    {
        /// <summary>
        ///   Requires that the <paramref name="argument"/> is less than <paramref name="limit"/>.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <param name="limit">
        ///   The limit that <paramref name="argument"/> must be less than.
        /// </param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the argument is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">Thrown if the requirement is not met.</exception>
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
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <param name="limit">
        ///   The limit that the <paramref name="argument"/> must be less than.
        /// </param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the argument is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThan<T>(this Argument<T> argument, T limit)
            where T : IComparable<T>
        {
            return IsLessThanImpl(argument, limit);
        }

        /// <summary>
        ///   Requires that the <paramref name="argument"/> is less than or equal to <paramref name="limit"/>
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <param name="limit">
        ///   The limit that the <paramref name="argument"/> must be less than or equal to.
        /// </param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the argument is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">Thrown if the requirement is not met.</exception>
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
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <param name="limit">
        ///   The limit that the <paramref name="argument"/> must be less than or equal to.
        /// </param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the argument is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsLessThanOrEqualTo<T>(this Argument<T> argument, T limit)
            where T : IComparable<T>
        {
            return IsLessThanOrEqualToImpl(argument, limit);
        }

        /// <summary>
        ///   Requires that the <paramref name="argument"/> is greater than <paramref name="limit"/>.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <param name="limit">
        ///   The limit that the <paramref name="argument"/> must be greater than.
        /// </param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the argument is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">Thrown if the requirement is not met.</exception>
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
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <param name="limit">
        ///   The limit that the <paramref name="argument"/> must be greater than.
        /// </param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the argument is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThan<T>(this Argument<T> argument, T limit)
            where T : IComparable<T>
        {
            return IsGreaterThanImpl(argument, limit);
        }

        /// <summary>
        ///   Requires that the <paramref name="argument"/> is greater than or equal to <paramref name="limit"/>.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <param name="limit">
        ///   The limit that the <paramref name="argument"/> must be greater than or equal to.
        /// </param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThanOrEqualTo<T>(this Argument<T> argument, object limit)
            where T : IComparable
        {
            return IsGreaterThanOrEqualToImpl(argument, limit);
        }

        /// <summary>
        ///   Requires that the <paramref name="argument"/> is greater than or equal to <paramref name="limit"/>.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <param name="limit">The limit that the <paramref name="argument"/> must be greater than or equal to.</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the argument is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsGreaterThanOrEqualTo<T>(this Argument<T> argument, T limit)
            where T : IComparable<T>
        {
            return IsGreaterThanOrEqualToImpl(argument, limit);
        }

        /// <summary>
        ///   Requires that the <paramref name="argument"/> falls with in the range specified by
        ///   <paramref name="min"/> and <paramref name="max"/>, inclusive.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the argument is null.</exception>
        /// <exception cref="T:System.ArgumetException">Thrown if the argument is not comparable to the range limits.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsInRange<T>(this Argument<T> argument, object min, object max)
            where T : IComparable
        {
            if (argument.Value == null)
            {
                throw ExceptionFactory.CreateNullException(argument);
            }

            if (argument.CompareValueTo(min) < 0)
            {
                throw ExceptionFactory.OutOfRange(
                    argument,
                    ExceptionMessages.Current.NotInRange_TooLow.Inject(min, max));
            }

            if (argument.CompareValueTo(max) > 0)
            {
                throw ExceptionFactory.OutOfRange(
                    argument,
                    ExceptionMessages.Current.NotInRange_TooHigh.Inject(min, max));
            }

            return argument;
        }

        /// <summary>
        ///   Requires that the <paramref name="argument"/> falls with in the range specified by
        ///   <paramref name="min"/> and <paramref name="max"/>, inclusive.
        ///   Throws an exception if the requirement is not met.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="T:Krav.Argument"/> to verify.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range</param>
        /// <returns>The verified <see cref="T:Krav.Argument"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the argument is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">Thrown if the requirement is not met.</exception>
        [DebuggerStepThrough]
        public static Argument<T> IsInRange<T>(this Argument<T> argument, T min, T max)
            where T : IComparable<T>
        {
            if (argument.Value == null)
            {
                throw ExceptionFactory.CreateNullException(argument);
            }

            if (argument.CompareValueTo(min) < 0)
            {
                throw ExceptionFactory.OutOfRange(
                    argument,
                    ExceptionMessages.Current.NotInRange_TooLow.Inject(min, max));
            }

            if (argument.CompareValueTo(max) > 0)
            {
                throw ExceptionFactory.OutOfRange(
                    argument,
                    ExceptionMessages.Current.NotInRange_TooHigh.Inject(min, max));
            }

            return argument;
        }

        private static Argument<T> IsLessThanImpl<T>(Argument<T> argument, object limit)
        {
            if (argument.Value == null)
            {
                throw ExceptionFactory.CreateNullException(argument);
            }

            if (argument.CompareValueTo(limit) >= 0)
            {
                throw ExceptionFactory.OutOfRange(
                    argument,
                    ExceptionMessages.Current.NotLessThan.Inject(limit, argument.Value));
            }

            return argument;
        }

        private static Argument<T> IsLessThanOrEqualToImpl<T>(Argument<T> argument, object limit)
        {
            if (argument.Value == null)
            {
                throw ExceptionFactory.CreateNullException(argument);
            }

            if (argument.CompareValueTo(limit) > 0)
            {
                throw ExceptionFactory.OutOfRange(
                    argument,
                    ExceptionMessages.Current.NotLessThanOrEqualTo.Inject(limit, argument.Value));
            }

            return argument;
        }

        private static Argument<T> IsGreaterThanImpl<T>(Argument<T> argument, object limit)
        {
            if (argument.Value == null)
            {
                throw ExceptionFactory.CreateNullException(argument);
            }

            if (argument.CompareValueTo(limit) <= 0)
            {
                throw ExceptionFactory.OutOfRange(
                    argument,
                    ExceptionMessages.Current.NotGreaterThan.Inject(limit, argument.Value));
            }

            return argument;
        }

        private static Argument<T> IsGreaterThanOrEqualToImpl<T>(Argument<T> argument, object limit)
        {
            if (argument.Value == null)
            {
                throw ExceptionFactory.CreateNullException(argument);
            }

            if (argument.CompareValueTo(limit) < 0)
            {
                throw ExceptionFactory.OutOfRange(
                    argument,
                    ExceptionMessages.Current.NotGreaterThanOrEqualTo.Inject(limit, argument.Value));
            }

            return argument;
        }

        private static int CompareValueTo<T>(this Argument<T> argument, object comparisonValue)
        {
            try
            {
                switch (argument.Value)
                {
                    case IComparable<T> comparable when comparisonValue is T value:
                        return comparable.CompareTo(value);
                    case IComparable argumentValue:
                        return argumentValue.CompareTo(comparisonValue);
                }
            }
            catch (ArgumentException)
            {
                var message = ExceptionMessages.Current.IncomparableTypes.Inject(
                    argument.GetType().FullName ?? argument.GetType().Name,
                    comparisonValue.GetType().FullName ?? comparisonValue.GetType().Name);
                throw ExceptionFactory.CreateArgumentException(argument, message);
            }

            throw new InvalidOperationException("This should not be possible, please report an issue at http://github.com/pmacn/Krav with the code used get this exception.");
        }
    }
}
