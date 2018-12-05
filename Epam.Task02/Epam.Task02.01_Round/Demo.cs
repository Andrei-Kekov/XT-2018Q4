using System;

public class Task02_1
{
    private static void Main()
    {
        double x, y, r;
        Console.WriteLine("Task 2.1. Round");

        Console.WriteLine("Enter the position of the circle:");
        Console.Write("x: ");
        if (!double.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("Incorrect value");
            return;
        }

        Console.Write("y: ");
        if (!double.TryParse(Console.ReadLine(), out y))
        {
            Console.WriteLine("Incorrect value");
            return;
        }

        Console.WriteLine("Enter the radius of the circle:");
        if (!double.TryParse(Console.ReadLine(), out r))
        {
            Console.WriteLine("Incorrect value");
            return;
        }

        Round circle;

        try
        {
            circle = new Round(x, y, r);
        }
        catch (ArgumentOutOfRangeException exc)
        {
            Console.WriteLine(exc.Message);
            return;
        }        

        Console.WriteLine("Here are the properties of the circle:");
        Console.WriteLine("C = " + circle.C);
        Console.WriteLine("S = " + circle.S);
    }
}