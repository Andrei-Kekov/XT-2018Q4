using System;

class Task01_2
{
    static void Main()
    {
        Console.WriteLine("Задача 1.3. Triangle");
        Console.WriteLine("Введите N:");
        uint n;

        if (uint.TryParse(Console.ReadLine(), out n))
        {
            uint i;
            uint j;
            for (i = 1u; i <= n; i++)
            {
                for (j = 1u; j <= i; j++)
                    Console.Write('*');
                Console.WriteLine();
            }
        }

        else
            Console.WriteLine("Некорректное значение.");
    }
}