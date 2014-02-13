# How to Contribute

## Getting Started

So you want to contribute to Require.That. Great! Contributions take many forms from 
submitting issues, writing docs, to making code changes. We welcome it all.

But first things first...

* Make sure you have a [GitHub account](https://github.com/signup/free)
* Submit a ticket for your issue, assuming one does not already exist.
  * Clearly describe the issue including steps to reproduce when it is a bug.
  * Make sure you fill in the earliest version that you know has the issue.
* Fork the repository on GitHub by clicking on the "Clone in Windows" button or 
run the following command in a git shell.
```
git clone git@github.com:pmacn/Require.That.git Require.That
```
* Make sure the project builds and all tests pass on your machine (I'll include
a fancy build script later, for now just build and run tests however you usually
do it).

## Making Changes

* Create a topic branch off master (don't work directly on master).
* Make commits of logical units.
* Provide descriptive commit messages in the proper format (GitHub for Windows 
  helps get the format correct).
* Make sure you have added the necessary tests for your changes.
* Run _all_ the tests to assure nothing else was accidentally broken.

## Submitting Changes

* Push your changes to a topic branch in your fork of the repository.
* Submit a pull request. Note what issue/issues your patch fixes.

Some things that will increase the chance that your pull request is accepted.

* Follow existing code conventions. Most of what we do follows standard .NET
  conventions except in a few places.
* Include unit tests that would otherwise fail without your code, but pass with 
  it.
* Update the documentation, the surrounding one, examples elsewhere, guides, 
  whatever is affected by your contribution


## Additional Resources

* I shamelessly stole this document from the guys over at [octokit.net](http://github.com/octokit/octokit.net)
* [General GitHub documentation](http://help.github.com/)
* [GitHub pull request documentation](http://help.github.com/send-pull-requests/)