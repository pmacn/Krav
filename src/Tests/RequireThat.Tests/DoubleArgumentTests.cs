using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RequireThat.Tests
{
    public class DoubleArgumentTests
    {
        public const string ArgumentName = "foo";

        public class IsANumber
        {
            [Fact]
            public void WhenNotANumber_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Double.NaN, ArgumentName).IsANumber());

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenANumber_ReturnsArgument()
            {
                var requireThatArgument = Require.That(Double.Epsilon, ArgumentName);
                
                var result = requireThatArgument.IsANumber();

                Assert.Same(requireThatArgument, result);
            }
        }
    }
}
