using System;
using RequireThat.Resources;
using Xunit;

namespace RequireThat.Tests
{
    public class ClassArgumentTests
    {
        private const string ArgumentName = "foo";

        public class IsNotNull
        {
            [Fact]
            public void WhenNull_ThrowsArgumentNullException()
            {
                object value = null;

                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(value, ArgumentName).IsNotNull());

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenNotNull_ReturnsArgument()
            {
                var item = new { Value = 42 };
                var requireThatObject = Require.That(item, ArgumentName);

                var result = requireThatObject.IsNotNull();
                
                Assert.Same(requireThatObject, result);
            }        
        }
    }
}