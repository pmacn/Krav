using System;
using Xunit;
using Xunit.Extensions;

namespace Krav.Tests
{
    public class ArgumentTests
    {
        public class IsOfType
        {
            private static readonly string ParameterName = Guid.NewGuid().ToString();

            private class UnexpectedType { }

            private class ExpectedType { }

            public class BaseType { }

            public class SubType : BaseType { }

            private static readonly ExpectedType expectedArgument = new ExpectedType();

            private static readonly UnexpectedType unexpectedArgument = new UnexpectedType();

            [Theory]
            [InlineData("foo", typeof(int))]
            [InlineData(1, typeof(string))]
            public void WhenPrimitiveIsNotOfType_ThrowsArgumentException<T>(T argument, Type expectedType)
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(argument, ParameterName).IsOfType(expectedType));

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Theory]
            [InlineData("foo", typeof(string))]
            [InlineData(1, typeof(int))]
            public void WhenPrimitiveIsOfType_ReturnsArgument<T>(T argument, Type expectedType)
            {
                var requireThatArgument = Require.That(argument, ParameterName);
                var result = requireThatArgument.IsOfType(expectedType);

                Assert.Same(requireThatArgument, result);
            }

            [Fact]
            public void WhenNotOfType_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(unexpectedArgument, ParameterName).IsOfType<ExpectedType>());

                Assert.Equal(ParameterName, ex.ParamName);
            }
            
            [Fact]
            public void WhenNotOfTypeWithMessage_ExceptionHasCustomMessage()
            {
                var message = "This type was unexpected";

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(unexpectedArgument, ParameterName).IsOfType<ExpectedType>(message));

                Assert.Contains(message, ex.Message);
            }

            [Fact]
            public void WhenOfType_DoesNotThrow()
            {
                Assert.DoesNotThrow(
                    () => Require.That(expectedArgument, ParameterName).IsOfType<ExpectedType>());
            }

            [Fact]
            public void WhenOfType_ReturnsArgument()
            {
                var requireThatArgument = Require.That(new ExpectedType(), ParameterName);

                var result = requireThatArgument.IsOfType<ExpectedType>();

                Assert.Same(requireThatArgument, result);
            }

            [Fact]
            public void WhenOfDerivedType_ReturnsArgument()
            {
                var argument = new SubType() as object;
                var requireThatArgument = Require.That(argument, ParameterName);

                var result = requireThatArgument.IsOfType<BaseType>();

                Assert.Same(requireThatArgument, result);
            }

            [Fact]
            public void WhenOfBaseType_ThrowsException()
            {
                var argument = new BaseType();

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(argument, ParameterName).IsOfType<SubType>());

                Assert.Equal(ParameterName, ex.ParamName);
            }

            // This Test is simply for documentation purposes and does not indicate a design feature.
            [Fact]
            public void WhenNull_TypeDetectionRevertsToParameterType()
            {
                ExpectedType argument = null;

                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That((object)argument, ParameterName).IsOfType<ExpectedType>());

                Assert.Equal(ParameterName, ex.ParamName);
            }
        }
    }
}
