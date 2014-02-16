using System;
using Xunit;

namespace Krav.Tests
{
    public class NullableArgumentTests
    {
        private static readonly string ParameterName = Guid.NewGuid().ToString();

        public class IsNotNull
        {
            public void WhenNull_ThrowsArgumentException()
            {
                int? nullable = null;
                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(nullable, ParameterName).IsNotNull());

                Assert.Equal(ParameterName, ex.ParamName);
            }

            public void WhenNotNull_ReturnsArgument()
            {
                int? nullableInt = 42;
                var requireThatNullableInt = Require.That(nullableInt, ParameterName);

                var result = requireThatNullableInt.IsNotNull();

                Assert.Same(requireThatNullableInt, result);
            }
        }
    }
}