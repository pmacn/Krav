using System;
using Xunit;

namespace RequireThat.Tests
{
    public class TypeArgumentTests
    {
        private static readonly string ParameterName = Guid.NewGuid().ToString();

        private class UnexpectedType { }

        private class ExpectedType { }

        public class Is
        {
            [Fact]
            public void WhenNull_ThrowsArgumentNullException()
            {
                var expectedType = typeof(bool);

                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(null as Type, ParameterName).Is(expectedType));

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenNotOfT_ThrowsArgumentException()
            {
                var typeArgument = typeof(UnexpectedType);
                var expectedType = typeof(ExpectedType);

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(typeArgument, ParameterName).Is(expectedType));

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenOfT_ReturnsArgument()
            {
                var expectedType = typeof(ExpectedType);
                var typeArgument = expectedType;
                var requireThatTypeArgument = Require.That(typeArgument, ParameterName);

                var result = requireThatTypeArgument.Is(expectedType);

                Assert.Same(requireThatTypeArgument, result);
            }
        }

        public class IsOfT
        {
            [Fact]
            public void WhenNull_ThrowsArgumentNullException()
            {
                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(null as Type, ParameterName).Is<bool>());

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenNotOfT_ThrowsArgumentException()
            {
                var typeArgument = typeof(UnexpectedType);

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(typeArgument, ParameterName).Is<ExpectedType>());

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenOfT_ReturnsArgument()
            {
                var typeArgument = typeof(ExpectedType);
                var requireThatTypeArgument = Require.That(typeArgument, ParameterName);

                var result = requireThatTypeArgument.Is<ExpectedType>();

                Assert.Same(requireThatTypeArgument, result);
            }
        }
    }
}