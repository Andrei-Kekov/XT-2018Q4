﻿using System;

public class Program
{
    public static void Sequence(uint n)
    {
        for (uint i = 1; i <= n && i > 0; i++)
        {
            Console.Write(i);

            if (i < n)
            {
                Console.Write(", ");
            }
        }
    }

    public static void Main()
    {
        Console.WriteLine("Task 0.1. Sequence");
        Console.WriteLine("Enter the value of N:");
        uint n;

        if (uint.TryParse(Console.ReadLine(), out n))
        {
            Sequence(n);
        }
        else
        {
            Console.WriteLine("Incorrect value.");
        }
    }
}