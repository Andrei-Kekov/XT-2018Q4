using System;

class Task00
{
    static void Square(uint N)
    {
        uint i;
        uint j;
        uint center = N / 2u + 1u;
        for (i = 1; i <= N; i++)
        {
            for (j = 1; j <= N; j++)
                if (i == center && j == center)
                    Console.Write(' ');
                else
                    Console.Write('*');
            Console.WriteLine();
        }
    }

    static void Main()
    {
        Console.WriteLine("Задача 0.3. Square");
        Console.WriteLine("Введите N:");
        uint N = uint.Parse(Console.ReadLine());
        Square(N);
        Console.ReadLine();
    }
}