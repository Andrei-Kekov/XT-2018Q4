using System;

class Task01_5
{
    static void Main()
    {
        Console.WriteLine("Задача 1.5. Sum of Numbers");
        uint s = 0u;
        for (uint i = 3u; i < 1000u; i++)
            if (i % 3u == 0 || i % 5u == 0)
                s += i;
        Console.WriteLine(s);
    }
}