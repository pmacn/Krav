using System;
using Xunit;

namespace RequireThat.Tests
{
    public class StringArgumentTests
    {
        private const string ArgumentName = "foo";

        public class IsNotNullOrEmpty
        {
            [Fact]
            public void WhenNull_ThrowsArgumentException()
            {
                string value = null;

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(value, ArgumentName).IsNotNullOrEmpty());

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenEmpty_ThrowsArgumentException()
            {
                var value = string.Empty;

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(value, ArgumentName).IsNotNullOrEmpty());

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenEmptyWithMessage_ThrowsExceptionWithMessage()
            {
                var message = "It was empty";

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(String.Empty, ArgumentName).IsNotNullOrEmpty(message));

                Assert.Contains(message, ex.Message);
            }

            [Fact]
            public void WhenNotEmpty_ReturnsArgument()
            {
                var requireThatString = Require.That("foo", ArgumentName);

                var result = requireThatString.IsNotNull();

                Assert.Same(requireThatString, result);
            }
        }

        public class IsNotNullOrWhiteSpace
        {
            [Fact]
            public void WhenNull_ThrowsArgumentException()
            {
                string value = null;

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(value, ArgumentName).IsNotNullOrWhiteSpace());

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenEmpty_ThrowsArgumentException()
            {
                string value = string.Empty;

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(value, ArgumentName).IsNotNullOrWhiteSpace());

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenWhiteSpace_ThrowsArgumentException()
            {
                string value = "\t   ";

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(value, ArgumentName).IsNotNullOrWhiteSpace());

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenWhiteSpaceWithMessage_ThrowsExceptionWithMessage()
            {
                var message = "It was whitespace";
                string value = "\t   ";

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(value, ArgumentName).IsNotNullOrWhiteSpace(message));

                Assert.Contains(message, ex.Message);
            }

            [Fact]
            public void WhenNotNullOrWhiteSpace_ReturnsArgument()
            {
                var requirement = Require.That("foo", ArgumentName);

                var result = requirement.IsNotNullOrWhiteSpace();

                Assert.Same(requirement, result);
            }
        }
    }
}