using System;

class Task00_1
{
    static void Sequence(uint n)
    {
        for (uint i = 1u; i <= n; i++)
            Console.Write(i + (i < n ? ", " : Environment.NewLine));
    }

    static void Main()
    {
        Console.WriteLine("Задача 0.1. Sequence");
        Console.WriteLine("Введите N:");
        uint n;
        if (uint.TryParse(Console.ReadLine(), out n))
            Sequence(n);
        else
            Console.WriteLine("Это не подходящее число.");
    }
}