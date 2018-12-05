using System;

public class Task02_2
{
    private static void Main()
    {
        double a, b, c;
        Console.WriteLine("Task 2.2. Triangle");

        Console.WriteLine("Enter the sides of the triangle:");
        Console.Write("a: ");
        if (!double.TryParse(Console.ReadLine(), out a) || a < 0)
        {
            Console.WriteLine("Incorrect value");
            return;
        }

        Console.Write("b: ");
        if (!double.TryParse(Console.ReadLine(), out b) || b < 0)
        {
            Console.WriteLine("Incorrect value");
            return;
        }

        Console.Write("c: ");
        if (!double.TryParse(Console.ReadLine(), out c) || c < 0)
        {
            Console.WriteLine("Incorrect value");
            return;
        }

        Triangle triangle;

        try
        {
            triangle = new Triangle(a, b, c);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
            return;
        }

        Console.WriteLine("Here are the properties of the circle:");
        Console.WriteLine("P = " + triangle.P);
        Console.WriteLine("S = " + triangle.S);
    }
}