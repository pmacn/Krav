using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RequireThat.Tests
{
    public class FloatArgumentTests
    {
        public const string ArgumentName = "foo";

        public class IsANumber
        {
            [Fact]
            public void WhenNotANumber()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Single.NaN, ArgumentName).IsANumber());

                Assert.Equal(ArgumentName, ex.ParamName);
            }
        }
    }
}
