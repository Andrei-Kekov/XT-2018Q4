using System;

public class Program
{
    public static void Triangle(uint n)
    {
        uint i;
        uint j;

        for (i = 1u; i <= n; i++)
        {
            for (j = 1u; j <= i; j++)
            {
                Console.Write('*');
            }

            Console.WriteLine();
        }
    }

    public static void Main()
    {
        Console.WriteLine("Task 1.2. Triangle");
        Console.WriteLine("Enter the value of N:");
        uint n;

        if (uint.TryParse(Console.ReadLine(), out n))
        {
            Triangle(n);
        }
        else
        {
            Console.WriteLine("Incorrect value.");
        }
    }
}