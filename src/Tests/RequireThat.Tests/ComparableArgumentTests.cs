using RequireThat.Resources;
using System;
using Xunit;

namespace RequireThat.Tests
{
    public class ComparableArgumentTests
    {
        private const string ArgumentName = "foo";

        public class IsLessThan
        {
            [Fact]
            public void WhenIsLess_ReturnsValidResult()
            {
                var requireThatRed = Require.That(Apple.RedDelicious, ArgumentName);
                var result = requireThatRed.IsLessThan(Apple.Fuji);

                Assert.Same(requireThatRed, result);
            }

            [Fact]
            public void WhenIncompatibleTypes_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Apple.RedDelicious, ArgumentName).IsLessThan(new Orange()));

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenIsGreater_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Apple.Fuji, ArgumentName).IsLessThan(Apple.RedDelicious));

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenIsNull_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(null as Apple, ArgumentName).IsLessThan(Apple.Fuji));
            }
        }

        public class IsLessThanOrEqual
        {
            [Fact]
            public void WhenIsLessOrEqual_ReturnsArgument()
            {
                var requireThatRed = Require.That(Apple.RedDelicious, ArgumentName);
                var result = requireThatRed
                    .IsLessThanOrEqualTo(Apple.RedDelicious)
                    .IsLessThanOrEqualTo(Apple.Fuji);

                Assert.Same(requireThatRed, result);
            }

            [Fact]
            public void IncompatibleTypes_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Apple.Fuji, ArgumentName).IsLessThanOrEqualTo(new Orange()));

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenIsGreater_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Apple.Fuji, ArgumentName).IsLessThanOrEqualTo(Apple.RedDelicious));

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenIsNull_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(null as Apple, ArgumentName).IsLessThanOrEqualTo(Apple.Fuji));

                Assert.Equal(ArgumentName, ex.ParamName);
            }
        }

        public class IsGreaterThan
        {
            [Fact]
            public void WhenIsGreater_ReturnsArgument()
            {
                var requireThatFuji = Require.That(Apple.Fuji, ArgumentName);

                var result = requireThatFuji.IsGreaterThan(Apple.RedDelicious);

                Assert.Same(requireThatFuji, result);
            }

            [Fact]
            public void IncompatibleTypes_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Apple.Fuji, ArgumentName).IsGreaterThan(new Orange()));

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenIsLess_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Apple.RedDelicious, ArgumentName).IsGreaterThan(Apple.Fuji));

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenIsNull_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(null as Apple, ArgumentName).IsGreaterThan(Apple.RedDelicious));

                Assert.Equal(ArgumentName, ex.ParamName);
            }

        }

        public class IsGreaterThanOrEqualTo
        {
            [Fact]
            public void WhenIsGreaterOrEqual_ReturnsValidResult()
            {
                var requireThatFuji = Require.That(Apple.Fuji, ArgumentName);

                var result = requireThatFuji
                    .IsGreaterThanOrEqualTo(Apple.RedDelicious)
                    .IsGreaterThanOrEqualTo(Apple.Fuji);

                Assert.Same(requireThatFuji, result);
            }

            [Fact]
            public void IncompatibleTypes_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Apple.Fuji, ArgumentName).IsGreaterThanOrEqualTo(new Orange()));

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenIsLess_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Apple.RedDelicious, ArgumentName).IsGreaterThanOrEqualTo(Apple.Fuji));

                Assert.Equal(ArgumentName, ex.ParamName);
            }

            [Fact]
            public void WhenIsNull_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(null as Apple, ArgumentName).IsGreaterThanOrEqualTo(Apple.RedDelicious));

                Assert.Equal(ArgumentName, ex.ParamName);
            }
        }

        [Fact]
        public void CanCompareDifferentNumericTypes()
        {
            var requireThatArgument = Require.That(0.01, ArgumentName);

            var result = requireThatArgument.IsLessThan(1);

            Assert.Same(requireThatArgument, result);
        }
    }

    public class Apple : IComparable, IComparable<Apple>
    {
        protected int awesomeFactor;

        private Apple(int awesomeFactor)
        {
            this.awesomeFactor = awesomeFactor;
        }

        public static Apple Fuji { get { return new Apple(9000); } }

        public static Apple RedDelicious { get { return new Apple(1); } }

        public int CompareTo(object obj)
        {
            if (obj is Apple)
                return CompareTo(obj as Apple);

            throw new ArgumentException("obj");
        }

        public int CompareTo(Apple other)
        {
            return this.awesomeFactor - other.awesomeFactor;
        }
    }

    public class Orange
    {

    }
}