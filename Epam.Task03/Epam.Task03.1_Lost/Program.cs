using System;
using System.Collections.Generic;

public class Program
{
    public static LinkedList<int> Lost(LinkedList<int> circle)
    {
        int i;
        int count = 0;
        Show(circle);

        while (circle.Count > 1)
        {
            for (i = circle.First.Value; i <= circle.Last.Value; i++)
            {
                if (circle.Contains(i))
                {
                    count++;

                    if (count == 2)
                    {
                        circle.Remove(i);
                        count = 0;
                        Show(circle);
                    }
                }
            }
        }

        return circle;
    }

    public static void Show(LinkedList<int> circle)
    {
        foreach (int x in circle)
        {
            Console.Write($"{x}, ");
        }

        Console.WriteLine();
    }

    public static void Main()
    {
        Console.WriteLine("Task 3.1. Lost");
        Console.WriteLine("Enter the value of N:");
        int n;

        if (!int.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("Invalid value.");
            return;
        }

        int[] numbers = new int[n];
        int i;

        for (i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i + 1;
        }

        LinkedList<int> circle = new LinkedList<int>(numbers);
        Lost(circle);
    }
}