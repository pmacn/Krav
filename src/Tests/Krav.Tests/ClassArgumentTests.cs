using System;
using Xunit;

namespace Krav.Tests
{
    public class ClassArgumentTests
    {
        private static readonly string ParameterName = Guid.NewGuid().ToString();

        public class IsNotNull
        {
            [Fact]
            public void WhenNull_ThrowsArgumentNullException()
            {
                object value = null;

                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(value, ParameterName).IsNotNull());

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenNullWithMessage_ThrowsExceptionWithMessage()
            {
                object value = null;
                var message = "It was null";

                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(value, ParameterName).IsNotNull(message));

                Assert.Equal(ParameterName, ex.ParamName);
                Assert.Contains(message, ex.Message);
            }

            [Fact]
            public void WhenNotNull_ReturnsArgument()
            {
                var item = new { Value = 42 };
                var requireThatObject = Require.That(item, ParameterName);

                var result = requireThatObject.IsNotNull();
                
                Assert.Same(requireThatObject, result);
            }        
        }
    }
}