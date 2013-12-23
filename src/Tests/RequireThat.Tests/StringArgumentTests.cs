using System;
using RequireThat.Resources;
using System.Text.RegularExpressions;
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
            public void WhenNotNullOrWhiteSpace_ReturnsArgument()
            {
                var requirement = Require.That("foo", ArgumentName);

                var result = requirement.IsNotNullOrWhiteSpace();

                Assert.Same(requirement, result);
            }

        }
    }
}