using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RequireThat.Tests
{
    public class LambdaArgumentTests
    {
        public class FailingRequirement
        {
            public string MyProperty { get; set; }

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
        }
    }
}
