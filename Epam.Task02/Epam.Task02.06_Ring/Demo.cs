using System;

public class Task02_1
{
    private static void Main()
    {
        double x, y, ri, ro;
        Console.WriteLine("Task 2.6. Ring");

        Console.WriteLine("Enter the position of the ring:");
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

        Console.WriteLine("Enter the inner radius of the ring:");
        if (!double.TryParse(Console.ReadLine(), out ri))
        {
            Console.WriteLine("Incorrect value");
            return;
        }

        Console.WriteLine("Enter the outer radius of the ring:");
        if (!double.TryParse(Console.ReadLine(), out ro))
        {
            Console.WriteLine("Incorrect value");
            return;
        }

        Ring ring;

        try
        {
            ring = new Ring(x, y, ri, ro);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
            return;
        }

        Console.WriteLine("Here are the properties of the ring:");
        Console.WriteLine("C = " + ring.C);
        Console.WriteLine("S = " + ring.S);
    }
}