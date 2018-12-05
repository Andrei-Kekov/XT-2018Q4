using System;

public class Task01_5
{
    public static uint SumOfNumbers(uint x, uint a1, uint a2)
    {
        return PartialSum(x, a1) + PartialSum(x, a2) - PartialSum(x, a1 * a2);
    }

    public static uint PartialSum(uint x, uint d)
    {
        uint n = x / d;
        return d * n * (n + 1) / 2;
    }

    public static void Main()
    {
        Console.WriteLine("Task 1.5. Sum of Numbers");
        Console.WriteLine(SumOfNumbers(1000u, 3u, 5u));
    }
}