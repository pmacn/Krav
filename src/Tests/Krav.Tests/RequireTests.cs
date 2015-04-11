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
                Require.That("foo");
            }

            [Fact]
            public void WithName_DoesNotThrow()
            {
                Require.That("foo", "argument");
            }
        }

        public class ThatStatement
        {
            [Fact]
            public void FalseStatement_ThrowsException()
            {
                const bool Statement = false;
                const string Message = "message";

                var ex = Assert.Throws<ArgumentException>(
                    () =>
                    {
                        Require.That(Statement, Message);
                    });

                Assert.Equal(Message, ex.Message);
                Assert.Equal(null, ex.ParamName);
            }

            [Fact]
            public void TrueStatement_DoesNotThrow()
            {
                const bool Statement = true;
                Require.That(Statement, "message");
            }
        }
    }
}