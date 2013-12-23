using System;
using Xunit;

namespace RequireThat.Tests
{
    public class GuidArgumentTests
    {
        private const string ArgumentName = "foo";

        public class IsNotEmpty
        {
            [Fact]
            public void WhenEmpty_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Guid.Empty, ArgumentName).IsNotEmpty());

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenNotEmpty_ReturnsArgument()
            {
                var requireThatGuid = Require.That(Guid.NewGuid(), ArgumentName);

                var result = requireThatGuid.IsNotEmpty();

                Assert.Same(requireThatGuid, result);
            }
        }
    }
}