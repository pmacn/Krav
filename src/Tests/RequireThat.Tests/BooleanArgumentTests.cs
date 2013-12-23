using System;
using Xunit;

namespace RequireThat.Tests
{
    public class BooleanArgumentTests
    {
        private const string ArgumentName = "foo";

        public class IsTrue
        {
            [Fact]
            public void WhenFalse_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(false, ArgumentName).IsTrue());

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenFalseWithCustomMessage_ThrowsExceptionWithMessage()
            {
                var expectedMessage = "False is not true";

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(false, ArgumentName).IsTrue(expectedMessage));

                Assert.Contains(expectedMessage, ex.Message);
            }
            
            [Fact]
            public void WhenTrue_DoesNotThrow()
            {
                Assert.DoesNotThrow(
                    () => Require.That(true, ArgumentName).IsTrue());
            }

            [Fact]
            public void WhenTrue_ReturnsArgument()
            {
                var requireThatArgument = Require.That(true, ArgumentName);

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
                    () => Require.That(true, ArgumentName).IsFalse());

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenTrueWithCustomMessage_ThrowsExceptionWithMessage()
            {
                string expectedMessage = "True is not false";

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(true, ArgumentName).IsFalse(expectedMessage));

                Assert.Contains(expectedMessage, ex.Message);
            }

            [Fact]
            public void WhenFalse_DoesNotThrow()
            {
                Assert.DoesNotThrow(() => Require.That(true, ArgumentName).IsTrue());
            }

            [Fact]
            public void WhenFalse_ReturnsArgument()
            {
                var requireThatArgument = Require.That(false, ArgumentName);
                var result = requireThatArgument.IsFalse();

                Assert.Same(requireThatArgument, result);
            }
        }
    }
}