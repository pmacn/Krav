# RequireThat

A guard clause library that started it's life as a fork of [`Ensure.That`](https://github.com/danielwertheim/Ensure.That).
And there are probably still some remnants of it in here somewhere. One
clear example would be the `StringExtensions` class that is almost
unchanged.

## Installation

You can install RequireThat through nuget

    Install-Package RequireThat

## Usage

RequireThat is used like this

    Require.That(argument, "argument").IsNotNull();
    Require.That(argument2, "argument2").IsANumber();

You can also use the Lambda-version of That. However keep in mind that the
cost for this is significantly higher (about a factor of 2 in tests on my
machine, your mileage may vary)

    Require.That(() => argument).IsNotNull();
    Require.That(() => argument2).IsANumber();

## I have special needs!

If a requirement method is not available for something you need you can
always use the `Require.That(statement, message)` method

    Require.That(foo != "bar", "foo was bar");

This will throw an `ArgumentException` if the statement evaluates to false.

If there's a good case to be made for including the requirement that you
need, you might also create an [issue](http://github.com/pmacn/Require.That/issues)
and/or [pull request](https://github.com/pmacn/Require.That/pulls) to have
it included

## Why not just add to Ensure.That?
Many of the changes made in `Require.That` could very well be put back in
to `Ensure.That`. But some of my main issues were about the DSL itself.
Much of it in the public API. I don't think those changes would have been
a good fit for pull requests.

## Why Require rather than Ensure?

It's what [Code Contracts](http://research.microsoft.com/en-us/projects/contracts/) uses for pre-conditions.