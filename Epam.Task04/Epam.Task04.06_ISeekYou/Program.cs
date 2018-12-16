using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Program
{
    public static IEnumerable<int> Find(int[] a)
    {
        foreach (int x in a)
        {
            if (x > 0)
            {
                yield return x;
            }
        }
    }

    public static IEnumerable<int> FindWithDelegateInstance(int[] a, Predicate<int> predicate)
    {
        foreach (int x in a)
        {
            if (predicate(x))
            {
                yield return x;
            }
        }
    }

    public static IEnumerable<int> FindWithAnonymousMethod(int[] a, Predicate<int> predicate)
    {
        foreach (int x in a)
        {
            if (predicate(x))
            {
                yield return x;
            }
        }
    }

    public static IEnumerable<int> FindWithLambda(int[] a, Predicate<int> predicate)
    {
        foreach (int x in a)
        {
            if (predicate(x))
            {
                yield return x;
            }
        }
    }

    public static IEnumerable<int> FindWithLINQ(int[] a)
    {
        IEnumerable<int> positive = from x in a
                                    where x > 0
                                    select x;

        return positive;
    }

    public static int[] RandomArray(int n, Random r)
    {
        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = r.Next(int.MinValue, int.MaxValue);
        }

        return a;
    }

    public static void Sort(long[] a)
    {
        if (a.Length == 0)
        {
            return;
        }

        Sort(a, 0, a.Length - 1);
    }

    public static void Sort(long[] a, int left, int right)
    {
        int i = left;
        int j = right;
        long x = a[(i + j) / 2];
        long y;

        do
        {
            while (a[i] < x && i < right)
            {
                i++;
            }

            while (x < a[j] && j > left)
            {
                j--;
            }

            if (i <= j)
            {
                y = a[i];
                a[i] = a[j];
                a[j] = y;
                i++;
                j--;
            }
        }
        while (i <= j);

        if (left < j)
        {
            Sort(a, left, j);
        }

        if (i < right)
        {
            Sort(a, i, right);
        }
    }

    public static bool IsPositive(int x)
    {
        return x > 0;
    }

    public static void Main()
    {
        Console.WriteLine("Task 4.6. I Seek You");
        Console.WriteLine("Please wait a few seconds...");

        Random r = new Random();
        int[] data = RandomArray(1000, r);
        Stopwatch stopwatch = new Stopwatch();
        long[] times = new long[101];
        long findTime;
        long findWithDelegateInstanceTime;
        long findWithAnonymousMethodTime;
        long findWithLambdaTime;
        long findWithLINQTime;
        Predicate<int> delegateInstance = IsPositive;
        int i;
        int j;
        const int QUERIES = 1000000;

        for (i = 0; i < times.Length; i++)
        {
            stopwatch.Start();

            for (j = 0; j < QUERIES; j++)
            {
                Find(data);
            }

            stopwatch.Stop();
            times[i] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
        }

        Sort(times);
        findTime = times[50];

        for (i = 0; i < times.Length; i++)
        {
            stopwatch.Start();

            for (j = 0; j < QUERIES; j++)
            {
                FindWithDelegateInstance(data, delegateInstance);
            }

            stopwatch.Stop();
            times[i] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
        }
        
        Sort(times);
        findWithDelegateInstanceTime = times[50];        

        for (i = 0; i < times.Length; i++)
        {
            stopwatch.Start();

            for (j = 0; j < QUERIES; j++)
            {
                FindWithAnonymousMethod(data, delegate(int x) { return x > 0; });
            }

            stopwatch.Stop();
            times[i] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
        }

        Sort(times);
        findWithAnonymousMethodTime = times[50];

        for (i = 0; i < times.Length; i++)
        {
            stopwatch.Start();

            for (j = 0; j < QUERIES; j++)
            {
                FindWithLambda(data, x => x > 0);
            }

            stopwatch.Stop();
            times[i] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
        }

        Sort(times);
        findWithLambdaTime = times[50];

        for (i = 0; i < times.Length; i++)
        {
            stopwatch.Start();

            for (j = 0; j < QUERIES; j++)
            {
                FindWithLINQ(data);
            }

            stopwatch.Stop();
            times[i] = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
        }

        Sort(times);
        findWithLINQTime = times[50];

        Console.WriteLine($"Median query time (per {QUERIES} queries):");
        Console.WriteLine($"Direct seek: {findTime} ms");
        Console.WriteLine($"Delegate instance: {findWithDelegateInstanceTime} ms");
        Console.WriteLine($"Anonymous method: {findWithAnonymousMethodTime} ms");
        Console.WriteLine($"Lambda expression: {findWithLambdaTime} ms");
        Console.WriteLine($"LINQ query: {findWithLINQTime} ms");
    }
}