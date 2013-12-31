using System;
using Xunit;

namespace RequireThat.Tests
{
    public class FloatArgumentTests
    {
        private static readonly string ParameterName = Guid.NewGuid().ToString();

        public class IsANumber
        {
            [Fact]
            public void WhenNotANumber()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Single.NaN, ParameterName).IsANumber());

                Assert.Equal(ParameterName, ex.ParamName);
            }
        }
    }
}
