﻿using System;
using Xunit;

namespace Krav.Tests
{
    public class ComparableArgumentTests
    {
        private static readonly string ParameterName = Guid.NewGuid().ToString();

        public class IsLessThan
        {
            [Fact]
            public void WhenIsLess_ReturnsValidResult()
            {
                var requireThatRed = Require.That(Apple.RedDelicious, ParameterName);
                var result = requireThatRed.IsLessThan(Apple.Fuji);

                Assert.Same(requireThatRed, result);
            }

            [Fact]
            public void WhenIncompatibleTypes_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Apple.RedDelicious, ParameterName).IsLessThan(new Orange()));

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenIsGreater_ThrowsArgumentOutOfRangeException()
            {
                var ex = Assert.Throws<ArgumentOutOfRangeException>(
                    () => Require.That(Apple.Fuji, ParameterName).IsLessThan(Apple.RedDelicious));

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenIsNull_ThrowsArgumentNullException()
            {
                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(null as Apple, ParameterName).IsLessThan(Apple.Fuji));
            }
        }

        public class IsLessThanOrEqualTo
        {
            [Fact]
            public void WhenIsLessOrEqual_ReturnsArgument()
            {
                var requireThatRed = Require.That(Apple.RedDelicious, ParameterName);
                var result = requireThatRed
                    .IsLessThanOrEqualTo(Apple.RedDelicious)
                    .IsLessThanOrEqualTo(Apple.Fuji);

                Assert.Same(requireThatRed, result);
            }

            [Fact]
            public void IncompatibleTypes_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Apple.Fuji, ParameterName).IsLessThanOrEqualTo(new Orange()));

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenIsGreater_ThrowsArgumentOutOfRangeException()
            {
                var ex = Assert.Throws<ArgumentOutOfRangeException>(
                    () => Require.That(Apple.Fuji, ParameterName).IsLessThanOrEqualTo(Apple.RedDelicious));

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenIsNull_ThrowsArgumentNullException()
            {
                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(null as Apple, ParameterName).IsLessThanOrEqualTo(Apple.Fuji));

                Assert.Equal(ParameterName, ex.ParamName);
            }
        }

        public class IsGreaterThan
        {
            [Fact]
            public void WhenIsGreater_ReturnsArgument()
            {
                var requireThatFuji = Require.That(Apple.Fuji, ParameterName);

                var result = requireThatFuji.IsGreaterThan(Apple.RedDelicious);

                Assert.Same(requireThatFuji, result);
            }

            [Fact]
            public void IncompatibleTypes_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Apple.Fuji, ParameterName).IsGreaterThan(new Orange()));

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenIsLess_ThrowsArgumentOutOfRangeException()
            {
                var ex = Assert.Throws<ArgumentOutOfRangeException>(
                    () => Require.That(Apple.RedDelicious, ParameterName).IsGreaterThan(Apple.Fuji));

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenIsNull_ThrowsArgumentNullException()
            {
                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(null as Apple, ParameterName).IsGreaterThan(Apple.RedDelicious));

                Assert.Equal(ParameterName, ex.ParamName);
            }

        }

        public class IsGreaterThanOrEqualTo
        {
            [Fact]
            public void WhenIsGreaterOrEqual_ReturnsValidResult()
            {
                var requireThatFuji = Require.That(Apple.Fuji, ParameterName);

                var result = requireThatFuji
                    .IsGreaterThanOrEqualTo(Apple.RedDelicious)
                    .IsGreaterThanOrEqualTo(Apple.Fuji);

                Assert.Same(requireThatFuji, result);
            }

            [Fact]
            public void IncompatibleTypes_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => Require.That(Apple.Fuji, ParameterName).IsGreaterThanOrEqualTo(new Orange()));

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenIsLess_ThrowsArgumentOutOfRangeException()
            {
                var ex = Assert.Throws<ArgumentOutOfRangeException>(
                    () => Require.That(Apple.RedDelicious, ParameterName).IsGreaterThanOrEqualTo(Apple.Fuji));

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenIsNull_ThrowsArgumentNullException()
            {
                var ex = Assert.Throws<ArgumentNullException>(
                    () => Require.That(null as Apple, ParameterName).IsGreaterThanOrEqualTo(Apple.RedDelicious));

                Assert.Equal(ParameterName, ex.ParamName);
            }
        }

        public class IsInRange
        {
            [Fact]
            public void WhenInRange_ReturnsArgument()
            {
                var requireThatFive = Require.That(5, ParameterName);

                var result = requireThatFive.IsInRange(1, 10);

                Assert.Same(requireThatFive, result);
            }

            [Fact]
            public void WhenOnLimit_ReturnsArgument()
            {
                var requireThatTen = Require.That(10, ParameterName);

                var result = requireThatTen.IsInRange(1, 10);

                Assert.Same(requireThatTen, result);
            }

            [Fact]
            public void WhenLessThanMin_ThrowsArgumentOutOfRangeException()
            {
                var requireThatZero = Require.That(0, ParameterName);

                Assert.Throws<ArgumentOutOfRangeException>(
                    () => requireThatZero.IsInRange(1, 10));
            }

            [Fact]
            public void WhenGreaterThanMax_ThrowsArgumentOutOfRangeException()
            {
                var requireThatEleven = Require.That(11, ParameterName);

                var ex = Assert.Throws<ArgumentOutOfRangeException>(
                    () => requireThatEleven.IsInRange(1, 10));

                Assert.Equal(ParameterName, ex.ParamName);
            }

            [Fact]
            public void WhenIncomparableTypes_ThrowsArgumentException()
            {
                var requireThatFive = Require.That(5, ParameterName);

                var ex = Assert.Throws<ArgumentException>(
                    () => requireThatFive.IsInRange("foo", "bar"));

                Assert.Equal(ParameterName, ex.ParamName);
            }
        }

        [Fact]
        public void CanCompareDifferentNumericTypes()
        {
            var requireThatArgument = Require.That(0.01, ParameterName);

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