# Krav

Another one of those pesky guard clause libraries. Krav means requirement in Swedish.


[![Build status](https://ci.appveyor.com/api/projects/status/6856jh3d3imek9t1/branch/master?svg=true)](https://ci.appveyor.com/project/pmacn/krav/branch/master)

## Installation

You can install `Krav` through nuget

    Install-Package Krav


## Usage

Using the library is as simple as this

    Require.That(foo).IsNotNull();
    Require.That(bar).IsANumber();
    Require.That(baz).IsANumber().GreaterThan(1).LessThan(4);

If you're really worried about performance you might want to use `Krav.Simple` instead.

## Simple?

Yes. If performance is more important than fancyness and readability in the project you're working on this is the one for you. It's really just a collection of static methods and predefined exception messages.

Install it via NuGet

    Install-Package Krav.Simple

And use it like this

    RequireThat.NotNull(foo, "foo");
    RequireThat.NotNullOrWhitespace(bar, "bar");

## I have special needs!

If a requirement method is not available for something you need you can always use the `Require.That(statement, message)` method.

    Require.That(foo != "bar", "foo was bar");

This will throw an `ArgumentException` with the provided message if the statement evaluates to false.

If there's a good case to be made for including the requirement that you
need, you might also create an [issue](http://github.com/pmacn/Krav/issues)
and/or [pull request](https://github.com/pmacn/Krav/pulls) to have
it included.

## You mentioned performance tests?

There's a `Krav.PerformanceTests` project that runs a number of iterations using each technique and displays the results.

    Non-lambda test results
    -----------------------
    Total time: 0.12 ms (404 ticks)
    Average time: 0.01 ms (20.2 ticks)
    Range: 0.01 - 0.01 ms (19 - 29 ticks)

    Simple test results
    -------------------
    Total time: 0.00 ms (12 ticks)
    Average time: 0.00 ms (0.6 ticks)
    Range: 0.00 - 0.00 ms (0 - 1 ticks)

But I would take this thing with a grain of salt. As you can see the range on Lambda tests is completely wonky.