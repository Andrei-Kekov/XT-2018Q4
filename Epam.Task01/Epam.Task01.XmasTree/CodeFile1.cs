using System;

public class Program
{
    public static void XmasTree(uint n)
    {
        for (uint i = 1u; i <= n; i++)
        {
            Triangle(n, i);
        }
    }

    public static void Triangle(uint center, uint height)
    {
        uint count;
        uint spaces;
        uint asterisks;

        for (uint row = 1u; row <= height; row++)
        {
            spaces = center - row;
            asterisks = (2u * row) - 1u;

            for (count = 1u; count <= spaces; count++)
            {
                Console.Write(' ');
            }

            for (count = 1u; count <= asterisks; count++)
            {
                Console.Write('*');
            }

            Console.WriteLine();
        }
    }
    
    public static void Main()
    {
        Console.WriteLine("Task 1.4. X-mas Tree");
        Console.WriteLine("Enter the value of N:");
        uint n;

        if (uint.TryParse(Console.ReadLine(), out n))
        {
            XmasTree(n);
        }
        else
        {
            Console.WriteLine("Incorrect value.");
        }
    }
}