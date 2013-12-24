using System;
using Xunit;

namespace RequireThat.Tests
{
    public class BooleanArgumentTests
    {
        private static readonly string ParameterName = Guid.NewGuid().ToString();

        public class IsTrue
        {
            [Fact]
            public void WhenFalse_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(false, ParameterName).IsTrue());

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenFalseWithCustomMessage_ThrowsExceptionWithMessage()
            {
                var expectedMessage = "False is not true";

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(false, ParameterName).IsTrue(expectedMessage));

                Assert.Contains(expectedMessage, ex.Message);
            }
            
            [Fact]
            public void WhenTrue_DoesNotThrow()
            {
                Assert.DoesNotThrow(
                    () => Require.That(true, ParameterName).IsTrue());
            }

            [Fact]
            public void WhenTrue_ReturnsArgument()
            {
                var requireThatArgument = Require.That(true, ParameterName);

                var result = requireThatArgument.IsTrue();

                Assert.Same(requireThatArgument, result);
            }
        }

        public class IsFalse
        {
            [Fact]
            public void WhenTrue_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(true, ParameterName).IsFalse());

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenTrueWithCustomMessage_ThrowsExceptionWithMessage()
            {
                string expectedMessage = "True is not false";

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(true, ParameterName).IsFalse(expectedMessage));

                Assert.Contains(expectedMessage, ex.Message);
            }

            [Fact]
            public void WhenFalse_DoesNotThrow()
            {
                Assert.DoesNotThrow(() => Require.That(true, ParameterName).IsTrue());
            }

            [Fact]
            public void WhenFalse_ReturnsArgument()
            {
                var requireThatArgument = Require.That(false, ParameterName);
                var result = requireThatArgument.IsFalse();

                Assert.Same(requireThatArgument, result);
            }
        }
    }
}