using System;
using System.Collections;
using System.Linq;
using Xunit;

namespace RequireThat.Tests
{
    public class EnumerableArgumentTests
    {
        private const string ArgumentName = "foo";

        public class IsNotEmpty
        {
            [Fact]
            public void WhenNull_ThrowsArgumentException()
            {
                IEnumerable nullEnumerable = null;

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(nullEnumerable, ArgumentName).IsNotEmpty());

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenEmpty_ThrowsArgumentException()
            {
                var emptyEnumerable = Enumerable.Empty<int>();

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(emptyEnumerable, ArgumentName).IsNotEmpty());

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenNotEmpty_DoesNotThrow()
            {
                Assert.DoesNotThrow(
                    () => Require.That(Enumerable.Range(0, 100)).IsNotEmpty());
            }

            [Fact]
            public void WhenNotEmpty_ReturnsArgument()
            {
                var requireThatEnumerable = Require.That(Enumerable.Range(0, 100), ArgumentName);

                var result = requireThatEnumerable.IsNotEmpty();

                Assert.Same(requireThatEnumerable, result);
            }
        }
    }
}