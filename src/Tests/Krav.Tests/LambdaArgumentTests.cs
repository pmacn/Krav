using System;
using Xunit;

namespace Krav.Tests
{
    public class LambdaArgumentTests
    {
        public class FailingRequirement
        {
            public string MyProperty { get; set; }

            [Fact(Skip = "This seems to be optimized when building in release, assuming that it just replaces myLocal with null which leads to an empty ParamName")]
            public void WhenLocal_ExceptionShouldHaveCorrectParamName()
            {
                string myLocal = null;
                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(() => myLocal).IsNotNull());

                Assert.Equal("myLocal", ex.ParamName);
            }

            [Fact]
            public void WhenLiteral_ParamNameIsEmpty()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(() => "").IsNotNullOrEmpty());

                Assert.Equal("", ex.ParamName);
            }

            [Fact]
            public void WhenStatement_ParameNameIsEmpty()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(() => String.Concat(" ", "\t")).IsNotNullOrWhiteSpace());

                Assert.Equal("", ex.ParamName);
            }

            [Fact]
            public void WhenStatementWithTwoArguments_ParameterNameIsEmpty()
            {
                var foo = "    ";
                var bar = "\t";
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(() => foo + bar).IsNotNullOrWhiteSpace());

                Assert.Equal("", ex.ParamName);
            }

            [Fact(Skip = "I don't know that we can actually make this one pass, but I would like to!")]
            public void WhenStatementWithSingleArgument_ParamNameIsEmpty()
            {
                var foo = "    ";
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(() => foo + "\t").IsNotNullOrWhiteSpace());

                Assert.Equal("", ex.ParamName);
            }

            [Fact]
            public void WhenNotLocalVariable_ParamNameIsEmpty()
            {
                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(() => MyProperty).IsNotNull());

                Assert.Equal("", ex.ParamName);
            }
        }
    }
}
