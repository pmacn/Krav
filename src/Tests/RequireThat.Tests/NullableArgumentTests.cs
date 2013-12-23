using System;
using Xunit;

namespace RequireThat.Tests
{
    public class NullableArgumentTests
    {
        private const string ArgumentName = "foo";

        public class IsNotNull
        {
            public void WhenNull_ThrowsArgumentException()
            {
                int? nullable = null;
                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(nullable, ArgumentName).IsNotNull());

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            public void WhenNotNull_ReturnsArgument()
            {
                int? nullableInt = 42;
                var requireThatNullableInt = Require.That(nullableInt, ArgumentName);

                var result = requireThatNullableInt.IsNotNull();

                Assert.Same(requireThatNullableInt, result);
            }
        }
    }
}