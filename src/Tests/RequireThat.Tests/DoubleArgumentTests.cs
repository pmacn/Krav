using System;
using Xunit;

namespace RequireThat.Tests
{
    public class DoubleArgumentTests
    {
        private static readonly string ParameterName = Guid.NewGuid().ToString();

        public class IsANumber
        {
            [Fact]
            public void WhenNotANumber_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Double.NaN, ParameterName).IsANumber());

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenANumber_ReturnsArgument()
            {
                var requireThatArgument = Require.That(Double.Epsilon, ParameterName);
                
                var result = requireThatArgument.IsANumber();

                Assert.Same(requireThatArgument, result);
            }
        }
    }
}
