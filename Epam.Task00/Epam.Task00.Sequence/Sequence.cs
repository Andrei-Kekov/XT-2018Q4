using System;

public class Task00_1
{
    public static void Sequence(uint n)
    {
        for (uint i = 1u; i <= n; i++)
        {
            Console.Write(i + (i < n ? ", " : Environment.NewLine));
        }
    }

    public static void Main()
    {
        Console.WriteLine("Task 0.1. Sequence");
        Console.WriteLine("Enter the value of N:");
        uint n;

        if (uint.TryParse(Console.ReadLine(), out n))
        {
            Sequence(n);
        }
        else
        {
            Console.WriteLine("Incorrect value.");
        }
    }
}