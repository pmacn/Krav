using System;
using Xunit;

namespace Krav.Tests
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

        public class ThatStatement
        {
            [Fact]
            public void FalseStatement_ThrowsException()
            {
                var statement = false;
                string message = "message";

                var ex = Assert.Throws<ArgumentException>(
                    () =>
                    {
                        Require.That(statement, message);
                    });

                Assert.Equal(message, ex.Message);
                Assert.Equal(null, ex.ParamName);
            }

            [Fact]
            public void TrueStatement_DoesNotThrow()
            {
                var statement = true;
                Assert.DoesNotThrow(
                    () => Require.That(statement, "message"));
            }
        }
    }
}