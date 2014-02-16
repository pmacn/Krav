using System;
using Xunit;

namespace Krav.Tests
{
    public class GuidArgumentTests
    {
        private static readonly string ParameterName = Guid.NewGuid().ToString();

        public class IsNotEmpty
        {
            [Fact]
            public void WhenEmpty_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Guid.Empty, ParameterName).IsNotEmpty());

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenNotEmpty_ReturnsArgument()
            {
                var requireThatGuid = Require.That(Guid.NewGuid(), ParameterName);

                var result = requireThatGuid.IsNotEmpty();

                Assert.Same(requireThatGuid, result);
            }
        }
    }
}