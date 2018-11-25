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
            for (i = 1u; i <= n; i++)
            {
                for (j = 1u; j <= n - i; j++)
                    Console.Write(' ');
                for (j = 1u; j <= 2u * i - 1u; j++)
                    Console.Write('*');
                Console.WriteLine();
            }
        }

        else
            Console.WriteLine("Некорректное значение.");
    }
}