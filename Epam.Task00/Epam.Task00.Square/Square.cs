using System;

public class Program
{
    public static void Square(uint n)
    {
        uint i;
        uint j;
        uint center = (n / 2u) + 1u;

        for (i = 1u; i <= n && i > 0; i++)
        {
            for (j = 1u; j <= n && j > 0; j++)
            {
                if(i == center && j == center)
                {
                    Console.Write(' ');
                }
                else
                {
                    Console.Write('*');
                }
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