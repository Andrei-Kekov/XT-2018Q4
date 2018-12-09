using System;

public class Program
{
    public static void AnotherTriangle(uint n)
    {
        uint count;
        uint spaces;
        uint asterisks;

        for (uint row = 1u; row <= n && n > 0; row++)
        {
            spaces = n - row;
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
        Console.WriteLine("Task 1.3. Another Triangle");
        Console.WriteLine("Enter the value of N:");
        uint n;

        if (uint.TryParse(Console.ReadLine(), out n))
        {
            AnotherTriangle(n);
        }
        else
        {
            Console.WriteLine("Incorrect value.");
        }
    }
}