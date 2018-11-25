using System;

class Task01_4
{
    static void Triangle(uint center, uint height)
    {
        uint i;
        uint j;
        for (i = 1u; i <= height; i++)
        {
            for (j = 1u; j <= center - i; j++)
                Console.Write(' ');
            for (j = 1u; j <= 2u * i - 1u; j++)
                Console.Write('*');
            Console.WriteLine();
        }
    }


    static void Main()
    {
        Console.WriteLine("Задача 1.4. X-mas Tree");
        Console.WriteLine("Введите N:");
        uint n;

        if (uint.TryParse(Console.ReadLine(), out n))
        {
            for (uint i = 1u; i <= n; i++)
                Triangle(n, i);
        }

        else
            Console.WriteLine("Некорректное значение.");

    }
}