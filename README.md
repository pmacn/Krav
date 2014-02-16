# Krav

It's another preconditions library! Krav means requirement in Swedish.

## Installation

You can install Krav through nuget

    Install-Package Krav

## Usage

RequireThat is used like this

    Require.That(argument, "argument").IsNotNull();
    Require.That(argument2, "argument2").IsANumber();

You can also use the Lambda-version of That. However keep in mind that the
cost for this is significantly higher (about 50% increase in tests on my
machine, your mileage may vary)

    Require.That(() => argument).IsNotNull();
    Require.That(() => argument2).IsANumber();

## I have special needs!

If a requirement method is not available for something you need you can
always use the `Require.That(statement, message)` method

    Require.That(foo != "bar", "foo was bar");

This will throw an `ArgumentException` with the provided message if the statement evaluates to false.

If there's a good case to be made for including the requirement that you
need, you might also create an [issue](http://github.com/pmacn/Krav/issues)
and/or [pull request](https://github.com/pmacn/Krav/pulls) to have
it included