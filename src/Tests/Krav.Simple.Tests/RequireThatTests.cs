using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Krav;
using Xunit;

public class RequireThatTests
{
    public class NotNull
    {
        [Fact]
        public void WhenNullObject_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(
                () => RequireThat.NotNull(null as object, "name"));
        }

        [Fact]
        public void WhenNonNullObject_DoesNotThrowException()
        {
            Assert.DoesNotThrow(
                () => RequireThat.NotNull(new object(), "name"));
        }

        [Fact]
        public void WhenNullNullable_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(
                () => RequireThat.NotNull(null as int?, "name"));
        }

        [Fact]
        public void WhenNullableWithoutValue_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(
                () => RequireThat.NotNull(new Nullable<int>(), "name"));
        }

        [Fact]
        public void WhenNullableWithValue_DoesNotThrow()
        {
            Assert.DoesNotThrow(
                () => RequireThat.NotNull(new Nullable<int>(1), "name"));
        }
    }

    public class NotNullOrEmpty
    {
        [Fact]
        public void WhenNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(
                () => RequireThat.NotNullOrEmpty(null as string, "name"));
        }

        [Fact]
        public void WhenEmptyString_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => RequireThat.NotNullOrEmpty("", "name"));
        }

        [Fact]
        public void WhenNotEmptyString_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => RequireThat.NotNullOrEmpty("value", "name"));
        }

        [Fact]
        public void WhenNullEnumerable_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(
                () => RequireThat.NotNullOrEmpty(null as IEnumerable, "name"));
        }

        [Fact]
        public void WhenEmptyEnumerable_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => RequireThat.NotNullOrEmpty(Enumerable.Empty<object>(), "name"));
        }

        [Fact]
        public void WhenNotEmptyEnumerable_DoesNotThrow()
        {
            Assert.DoesNotThrow(
                () => RequireThat.NotNullOrEmpty(Enumerable.Range(1, 1), "name"));
        }
    }

    public class ContainsNoNull
    {
        [Fact]
        public void WhenNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(
                () => RequireThat.DoesNotContainNull(null as IEnumerable, "name"));
        }

        [Fact]
        public void WhenContainsNull_ThrowsException()
        {
            var enumerable = new [] { new object(), null, new object() };
            Assert.Throws<ArgumentException>(
                () => RequireThat.DoesNotContainNull(enumerable, "name"));
        }

        [Fact]
        public void WhenContainsNoNull_DoesNotThrow()
        {
            var enumerable = new[] { new object(), new object() };
            Assert.DoesNotThrow(
                () => RequireThat.DoesNotContainNull(enumerable, "name"));
        }
    }

    public class NotNullOrWhitespace
    {
        [Fact]
        public void WhenNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(
                () => RequireThat.NotNullOrWhitespace(null, "name"));
        }

        [Fact]
        public void WhenEmpty_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => RequireThat.NotNullOrWhitespace("", "name"));
        }

        [Fact]
        public void WhenWhitespace_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => RequireThat.NotNullOrWhitespace(" ", "name"));
        }

        [Fact]
        public void WhenNotWhitespace_DoesNotThrow()
        {
            Assert.DoesNotThrow(
                () => RequireThat.NotNullOrWhitespace("value", "name"));
        }
    }

    public class IsANumber
    {
        [Fact]
        public void WhenSingleIsNaN_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => RequireThat.IsNumber(Single.NaN, "name"));
        }

        [Fact]
        public void WhenSingleIsNumber_DoesNotThrow()
        {
            Assert.DoesNotThrow(
                () => RequireThat.IsNumber(0.0f, "name"));
        }

        [Fact]
        public void WhenDoubleIsNaN_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => RequireThat.IsNumber(Double.NaN, "name"));
        }

        [Fact]
        public void WhenDoubleIsNumber_DoesNotThrow()
        {
            Assert.DoesNotThrow(
                () => RequireThat.IsNumber(0.0d, "name"));
        }
    }

    public class OfType
    {
        [Fact]
        public void WhenNotOfType_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => RequireThat.IsOfType<IEnumerable>(new object(), "name"));
        }

        [Fact]
        public void WhenOfType_DoesNotThrow()
        {
            Assert.DoesNotThrow(
                () => RequireThat.IsOfType<int>(1, "name"));
        }

        [Fact]
        public void WhenOfDerivedType_DoesNotThrow()
        {
            Assert.DoesNotThrow(
                () => RequireThat.IsOfType<IEnumerable>(new List<string>(), "name"));
        }
    }
}
