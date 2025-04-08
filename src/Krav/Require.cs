namespace Krav
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///   Access point for creating <see cref="T:Krav.Argument"/>s
    /// </summary>
    public static class Require
    {
        public static Argument<T> That<T>(
            T value,
            [CallerArgumentExpression("value")] string name = "")
        {
            return new Argument<T>(value, name);
        }
    }
}