using System;

public class Task00_3
{
    public static void Square(uint n)
    {
        uint i;
        uint j;
        uint center = (n / 2u) + 1u;

        for (i = 1u; i <= n; i++)
        {
            for (j = 1u; j <= n; j++)
            {
                Console.Write(i == center && j == center ? ' ' : '*');
            }

            Console.WriteLine();
        }
    }

    public static void Main()
    {
        Console.WriteLine("Task 0.3. Square");
        Console.WriteLine("Enter the value of N:");
        uint n;

        if (uint.TryParse(Console.ReadLine(), out n))
        {
            Square(n);
        }
        else
        {
            Console.WriteLine("Incorrect value.");
        }
    }
}