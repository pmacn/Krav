using Xunit;

namespace RequireThat.Tests
{
    public class RequireTests
    {
        public class That
        {
            [Fact]
            public void WithoutName_DoesNotThrow()
            {
                Assert.DoesNotThrow(
                    () => Require.That("foo", "argument"));
            }

            [Fact]
            public void WithName_DoesNotThrow()
            {
                Assert.DoesNotThrow(
                    () => Require.That("foo", "argument"));
            }
        }
    }
}