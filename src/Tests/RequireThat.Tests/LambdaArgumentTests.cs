using System;
using Xunit;

namespace RequireThat.Tests
{
    public class LambdaArgumentTests
    {
        public class FailingRequirement
        {
            public string MyProperty { get; set; }

            public string myField;

            [Fact]
            public void WhenField_ExceptionShouldHaveCorrectParamName()
            {
                string myArgument = null;
                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(() => myArgument).IsNotNull());

                Assert.Equal("myArgument", ex.ParamName);
            }

            [Fact]
            public void WhenLiteral_ParamNameIsEmptyString()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(() => "").IsNotNullOrEmpty());

                Assert.Equal("", ex.ParamName);
            }

            [Fact]
            public void WhenStatement_ParameNameIsEmptyString()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(() => String.Concat(" ", "\t")).IsNotNullOrWhiteSpace());

                Assert.Equal("", ex.ParamName);
            }

            [Fact]
            public void WhenStatementWithTwoArguments_ParameterNameIsEmptyString()
            {
                var foo = "    ";
                var bar = "\t";
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(() => foo + bar).IsNotNullOrWhiteSpace());

                Assert.Equal("", ex.ParamName);
            }

            [Fact(Skip = "I don't know that we can actually make this one pass, but I would like to!")]
            public void WhenStatementWithSingleArgument_ParamNameIsEmptyString()
            {
                var foo = "    ";
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(() => foo + "\t").IsNotNullOrWhiteSpace());

                Assert.Equal("", ex.ParamName);
            }

            [Fact]
            public void WhenNotLocalVariable_ParamNameIsEmptyString()
            {
                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(() => MyProperty).IsNotNull());

                Assert.Equal("", ex.ParamName);
            }
        }
    }
}
