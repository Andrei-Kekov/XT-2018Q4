using System;
class Task00_2
{
    static bool Simple(uint n)
    {
        if (n <= 1u)
            return false;
        uint stop = (uint) Math.Sqrt(n);
        for (uint i = 2u; i <= stop; i++)
            if (n % i == 0u)
                return false;
        return true;
    }

    static void Main()
    {
        Console.WriteLine("задача 0.2. Simple");
        Console.WriteLine("Введите N:");
        uint n;
        if (uint.TryParse(Console.ReadLine(), out n))
            Console.WriteLine(Simple(n));
        else
            Console.WriteLine("Это не подходящее число.");
    }
}