using System;

class Task00
{
    static string Sequence(uint N)
    {
        string s = "";
        for (uint i = 1u; i <= N; i++)
            if (i == N)
                s += i;
            else
                s += (i + ", ");
        return s;
    }

    static void Main()
    {
        Console.WriteLine("Задача 0.1. Sequence");
        Console.WriteLine("Введите N:");
        uint N = uint.Parse(Console.ReadLine());
        Console.WriteLine(Sequence(N));
    }
}