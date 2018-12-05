using System;

class Task01_3
{
    static void Main()
    {
        Console.WriteLine("Задача 1.2. Another Triangle");
        Console.WriteLine("Введите N:");
        uint n;

        if (uint.TryParse(Console.ReadLine(), out n))
        {
            uint i;
            uint j;
            uint center = n / 2u + 1u;
            for (i = 1; i <= n; i++)
            {
                for (j = 1; j <= center - i; j++)
                    Console.Write(' ');
                for (j = 1; j <= 2u * i - 1u; j++)
                    Console.Write('*');
                Console.WriteLine();
            }
        }

        else
            Console.WriteLine("Некорректное значение.");
    }
}