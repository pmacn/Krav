
using System;
namespace RequireThat
{
    public static class Require
    {
        public static Argument<T> That<T>(T value)
        {
            return new Argument<T>(String.Empty, value);
        }

        public static Argument<T> That<T>(T value, string name)
        {
            return new Argument<T>(name, value);
        }
    }
}