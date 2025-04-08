namespace Krav
{
    /// <summary>
    /// Provides default exception messages used by the guard clause validations.
    /// Override or replace <see cref="Current"/> to customize messaging.
    /// </summary>
    public class ExceptionMessages
    {
        static ExceptionMessages()
        {
            Current = new ExceptionMessages();
        }

        /// <summary>
        /// Gets or sets the current instance used for resolving exception messages.
        /// Can be replaced to customize global validation messages.
        /// </summary>
        public static ExceptionMessages Current { get; set; }

        /// <summary>Gets the message for values expected to be greater than or equal to a given threshold.</summary>
        public virtual string NotGreaterThanOrEqualTo => "Value expected to be greater than or equal to '{0}', but was '{1}'.";

        /// <summary>Gets the message for values expected to be greater than a given threshold.</summary>
        public virtual string NotGreaterThan => "Value expected to be greater than '{0}', but was '{1}'.";

        /// <summary>Gets the message for values exceeding the upper bound of an expected range.</summary>
        public virtual string NotInRange_TooHigh => "Value expected to be in range '{0}' - '{1}', but was greater than '{1}'.";

        /// <summary>Gets the message for values falling below the lower bound of an expected range.</summary>
        public virtual string NotInRange_TooLow => "Value expected to be in range '{0}' - '{1}', but was less than '{0}'.";

        /// <summary>Gets the message for empty collections when non-empty is required.</summary>
        public virtual string EmptyCollection => "Empty collection is not allowed.";

        /// <summary>Gets the message for disallowed empty Guid values.</summary>
        public virtual string EmptyGuid => "Empty Guid is not allowed.";

        /// <summary>Gets the message for null values where a non-null is required.</summary>
        public virtual string WasNull => "Value can not be null.";

        /// <summary>Gets the message for strings containing only whitespace characters.</summary>
        public virtual string WasWhiteSpace => "The string can not consist only of white-space.";

        /// <summary>Gets the message for expressions that were expected to be false.</summary>
        public virtual string NotFalse => "Expected an expression that evaluates to false.";

        /// <summary>Gets the message for expressions that were expected to be true.</summary>
        public virtual string NotTrue => "Expected an expression that evaluates to true.";

        /// <summary>Gets the message for type mismatches between expected and actual types.</summary>
        public virtual string NotOfType => "The param is not of expected type. Expected: '{0}' but was '{1}'.";

        /// <summary>Gets the message for values expected to be less than a given threshold.</summary>
        public virtual string NotLessThan => "Value expected to be less than '{0}', but was '{1}'.";

        /// <summary>Gets the message for values expected to be less than or equal to a given threshold.</summary>
        public virtual string NotLessThanOrEqualTo => "Value expected  to be less than or equal to '{0}', but was '{1}'.";

        /// <summary>Gets the message for empty strings where content is expected.</summary>
        public virtual string WasEmptyString => "Value can not be an empty string.";

        /// <summary>Gets the message for mismatched runtime types for a value expected to be a specific type.</summary>
        public virtual string IsNotExpectedType => "Type value is expected to be '{0}', but was '{1}'.";

        /// <summary>Gets the message for attempted comparisons between incompatible types.</summary>
        public virtual string IncomparableTypes => "Cannot compare items of type '{0}' and '{1}'";

        /// <summary>Gets the message for double values that are NaN where a number is expected.</summary>
        public virtual string IsNotANumber => "Value is required to be a number but was Not a Number.";

        /// <summary>Gets the message for collections that contain one or more null elements.</summary>
        public string ContainedNull => "The collection cannot contain null values";
    }
}
