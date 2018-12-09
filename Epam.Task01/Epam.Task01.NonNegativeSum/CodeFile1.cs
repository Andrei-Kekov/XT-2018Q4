using System;

public class Program
{
    public static int[] RandomArray(int n)
    {
        Random r = new Random();
        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = r.Next(-10, 11);
        }

        return a;
    }

    public static void Display(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        { 
        Console.Write(a[i] + "; ");
        }

        Console.WriteLine();
    }

    public static int NonNegativeSum(int[] a)
    {
        int s = 0;

        foreach (int x in a)
        {
            if (x > 0)
            {
                s += x;
            }
        }

        return s;
    }

    public static void Main()
    {
        Console.WriteLine("Task 1.9. Non-Negative Sum");
        Console.WriteLine("Initial array:");
        int[] a = RandomArray(10);
        Display(a);
        Console.WriteLine($"The sum of the non-negative elements is {NonNegativeSum(a)}");
    }
}