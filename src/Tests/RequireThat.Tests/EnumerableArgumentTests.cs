using System;
using System.Collections;
using System.Linq;
using Xunit;

namespace RequireThat.Tests
{
    public class EnumerableArgumentTests
    {
        private static readonly string ParameterName = Guid.NewGuid().ToString();

        public class IsNotEmpty
        {
            [Fact]
            public void WhenNull_ThrowsArgumentNullException()
            {
                IEnumerable nullEnumerable = null;

                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(nullEnumerable, ParameterName).IsNotEmpty());

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenEmpty_ThrowsArgumentException()
            {
                var emptyEnumerable = Enumerable.Empty<int>();

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(emptyEnumerable, ParameterName).IsNotEmpty());

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenEmptyWithMessage_ThrowsExceptionWithMessage()
            {
                var emptyEnumerable = Enumerable.Empty<int>();
                var message = "It was empty";

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(emptyEnumerable, ParameterName).IsNotEmpty(message));

                Assert.Contains(message, ex.Message);
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
                var requireThatEnumerable = Require.That(Enumerable.Range(0, 100), ParameterName);

                var result = requireThatEnumerable.IsNotEmpty();

                Assert.Same(requireThatEnumerable, result);
            }
        }
    }
}