using System;

class Task00_1
{
    static void Square(uint n)
    {
        uint i;
        uint j;
        uint center = n / 2u + 1u;
        for (i = 1; i <= n; i++)
        {
            for (j = 1; j <= n; j++)
                Console.Write(i == center && j == center? ' ' : '*');
            Console.WriteLine();
        }
    }

    static void Main()
    {
        Console.WriteLine("Задача 0.3. Square");
        Console.WriteLine("Введите N:");
        uint n;
        if (uint.TryParse(Console.ReadLine(), out n))
            Square(n);
        else
            Console.WriteLine("Это не подходящее число.");
    }
}