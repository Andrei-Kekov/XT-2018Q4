using System;

public class Program
{
    public static double Rectangle(double a, double b)
    {
        if (a < 0.0 || b < 0.0)
        {
            throw new ArgumentOutOfRangeException("The sides of a rectangle must be non-negative!");
        }

        return a * b;
    }

    public static void Main()
    {
        Console.WriteLine("Task 1.1. Rectangle");
        Console.WriteLine("Enter the sides of a rectangle.");
        Console.Write("a: ");
        double a;

        if (!double.TryParse(Console.ReadLine(), out a) || a <= 0.0)
        {
            Console.WriteLine("Incorrect value.");
            return;
        }

        Console.Write("b: ");
        double b;

        if (!double.TryParse(Console.ReadLine(), out b) || b <= 0.0)
        {
            Console.WriteLine("Incorrect value.");
            return;
        }

        Console.WriteLine("The area of the triangle is " + Rectangle(a, b));
    }
}