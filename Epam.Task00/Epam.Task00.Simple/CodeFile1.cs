using System;
class Task00
{
    static bool Simple(uint N)
    {
        if (N <= 1u)
            return false;
        for (uint i = 2u; i <= N / 2u; i++)
            if (N % i == 0u)
                return false;
        return true;
    }

    static void Main()
    {
        Console.WriteLine("задача 0.2. Simple");
        Console.WriteLine("Введите N:");
        uint N = uint.Parse(Console.ReadLine());
        Console.WriteLine(Simple(N));
        Console.ReadLine();
    }
}