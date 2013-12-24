using System;
using Xunit;

namespace RequireThat.Tests
{
    public class TypeArgumentTests
    {
        private const string ArgumentName = "foo";

        private class UnexpectedType { }

        private class ExpectedType { }

        public class Is
        {
            [Fact]
            public void WhenNull_ThrowsArgumentException()
            {
                var expectedType = typeof(bool);

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(null as Type, ArgumentName).Is(expectedType));

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenNotOfT_ThrowsArgumentException()
            {
                var typeArgument = typeof(UnexpectedType);
                var expectedType = typeof(ExpectedType);

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(typeArgument, ArgumentName).Is(expectedType));

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenOfT_ReturnsArgument()
            {
                var expectedType = typeof(ExpectedType);
                var typeArgument = expectedType;
                var requireThatTypeArgument = Require.That(typeArgument, ArgumentName);

                var result = requireThatTypeArgument.Is(expectedType);

                Assert.Same(requireThatTypeArgument, result);
            }
        }

        public class IsOfT
        {
            [Fact]
            public void WhenNull_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(null as Type, ArgumentName).Is<bool>());

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenNotOfT_ThrowsArgumentException()
            {
                var typeArgument = typeof(UnexpectedType);

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(typeArgument, ArgumentName).Is<ExpectedType>());

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenOfT_ReturnsArgument()
            {
                var typeArgument = typeof(ExpectedType);
                var requireThatTypeArgument = Require.That(typeArgument, ArgumentName);

                var result = requireThatTypeArgument.Is<ExpectedType>();

                Assert.Same(requireThatTypeArgument, result);
            }
        }
    }
}