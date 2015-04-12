namespace Krav
{
    public class ExceptionMessages
    {
        static ExceptionMessages()
        {
            Current = new ExceptionMessages();
        }

        public static ExceptionMessages Current { get; set; }

        public virtual string NotGreaterThanOrEqualTo
        {
            get { return "Value expected to be greater than or equal to '{0}', but was '{1}'."; }
        }

        public virtual string NotGreaterThan
        {
            get { return "Value expected to be greater than '{0}', but was '{1}'."; }
        }

        public virtual string NotInRange_TooHigh
        {
            get { return "Value expected to be in range '{0}' - '{1}', but was greater than '{1}'."; }
        }

        public virtual string NotInRange_TooLow
        {
            get { return "Value expected to be in range '{0}' - '{1}', but was less than '{0}'."; }
        }

        public virtual string EmptyCollection
        {
            get { return "Empty collection is not allowed."; }
        }

        public virtual string EmptyGuid
        {
            get { return "Empty Guid is not allowed."; }
        }

        public virtual string WasNull
        {
            get { return "Value can not be null."; }
        }

        public virtual string WasWhiteSpace
        {
            get { return "The string can not consist only of white-space."; }
        }

        public virtual string NotFalse
        {
            get { return "Expected an expression that evaluates to false."; }
        }

        public virtual string NotTrue
        {
            get { return "Expected an expression that evaluates to true."; }
        }

        public virtual string NotOfType
        {
            get { return "The param is not of expected type. Expected: '{0}' but was '{1}'."; }
        }

        public virtual string NotLessThan
        {
            get { return "Value expected to be less than '{0}', but was '{1}'."; }
        }

        public virtual string NotLessThanOrEqualTo
        {
            get { return "Value expected  to be less than or equal to '{0}', but was '{1}'."; }
        }

        public virtual string WasEmptyString
        {
            get { return "Value can not be an empty string."; }
        }

        public virtual string IsNotExpectedType
        {
            get { return "Type value is expected to be '{0}', but was '{1}'."; }
        }

        public virtual string IncomparableTypes
        {
            get { return "Cannot compare items of type '{0}' and '{1}'"; }
        }

        public virtual string IsNotANumber
        {
            get { return "Value is required to be a number but was Not a Number."; }
        }

        public string ContainedNull
        {
            get { return "The collection cannot contain null values"; }
        }
    }
}
