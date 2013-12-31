# RequireThat

A guard clause library that started it's life as a fork of [`Ensure.That`](https://github.com/danielwertheim/Ensure.That). And there are probably still some remnants of it in here somewhere. One clear example would be the `StringExtensions` class that is almost unchanged.

## How to install

You can install RequireThat through nuget

    Install-Package RequireThat

## How to use

RequireThat is used like this

    Require.That(argument, "argument").IsNotNull();
    Require.That(argument2, "argument2").IsANumber();

You can also use the Lambda-version of That. However keep in mind that the
cost for this is significantly higher (about a factor of 2 in tests on my machine, your mileage may vary)

    Require.That(() => argument).IsNotNull();
    Require.That(() => argument2).IsANumber();

## Why not just add to Ensure.That?
Many of the changes made in `Require.That` could very well be put back in to `Ensure.That`. But some of my main issues were about the DSL itself. Much of it in the public API. I don't think those changes would have been a good fit for pull requests.

## Why Require rather than Ensure?

It's what [Code Contracts](http://research.microsoft.com/en-us/projects/contracts/) uses for pre-conditions.