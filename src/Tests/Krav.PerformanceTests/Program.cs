﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Krav.PerformanceTests
{
    /// <summary>
    ///   This thing is a horrible mess but it's just meant to give an idea of performance
    ///   differences between lambda and non-lambda arguments
    /// </summary>
    class Program
    {
        private static Stopwatch stopwatch = new Stopwatch();

        private const int numberOfIterations = 20;

        private const int callsPerIteration = 50;

        static void Main(string[] args)
        {
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            DoWarmup();

            var nonLambdaResults = RunNonLambdaTests();
            var simpleResults = RunSimpleTests();

            PrintResults("Non-lambda test results", nonLambdaResults);
            PrintResults("Simple test results", simpleResults);

            Console.ReadKey();
        }

        private static void DoWarmup()
        {
            var foo = Guid.NewGuid().ToString() + Environment.TickCount.ToString();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < 2000)
            {
                Require.That(foo, "foo").IsNotNullOrEmpty();
                RequireThat.NotNullOrEmpty(foo, "foo");
            }

            stopwatch.Stop();
        }

        private static long[] RunNonLambdaTests()
        {
            Console.WriteLine("Running {0} iterations of {1} non-lambda requirements each.", numberOfIterations, callsPerIteration);
            var results = new long[numberOfIterations];
            for (int i = 0; i < numberOfIterations; i++)
            {
                var foo = Guid.NewGuid().ToString() + Environment.TickCount.ToString();
                stopwatch.Reset();
                stopwatch.Start();
                for (int callCount = 0; callCount < callsPerIteration; callCount++)
                    Require.That(foo, "foo").IsNotNullOrEmpty();

                stopwatch.Stop();
                results[i] = stopwatch.ElapsedTicks;
            }

            return results;
        }

        private static long[] RunSimpleTests()
        {
            Console.WriteLine("Running {0} iterations of {1} simple requirements each.", numberOfIterations, callsPerIteration);
            var results = new long[numberOfIterations];
            for (int i = 0; i < numberOfIterations; i++)
            {
                var foo = Guid.NewGuid().ToString() + Environment.TickCount.ToString();
                stopwatch.Reset();
                stopwatch.Start();
                for (int callCount = 0; callCount < callsPerIteration; callCount++)
                    RequireThat.NotNullOrEmpty(foo, "foo");

                stopwatch.Stop();
                results[i] = stopwatch.ElapsedTicks;
            }

            return results;
        }

        private static void PrintResults(string header, long[] results)
        {
            var ticksToMsDivisor = (Stopwatch.Frequency / 1000);
            Console.WriteLine();
            Console.WriteLine(header);
            Console.WriteLine(new String('-', header.Length));
            Console.WriteLine("Total time: {0:0.00} ms ({1} ticks)", (double)results.Sum() / ticksToMsDivisor, results.Sum());
            Console.WriteLine("Average time: {0:0.00} ms ({1} ticks)", results.Average() / ticksToMsDivisor, results.Average());
            Console.WriteLine("Range: {0:0.00} - {1:0.00} ms ({2} - {3} ticks)", (double)results.Min() / ticksToMsDivisor, (double)results.Max() / ticksToMsDivisor, results.Min(), results.Max());
        }
    }
}
