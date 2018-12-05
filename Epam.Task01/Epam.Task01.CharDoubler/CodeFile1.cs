using System;

public class Task01_12
{
    public static void Main()
    {
        Console.WriteLine("Задача 1.12. Char Doubler");
        Console.Write("Введите первую строку: ");
        string s1 = Console.ReadLine();
        Console.Write("Введите вторую строку: ");
        string s2 = Console.ReadLine();
        Console.Write("Результирующая строка: ");

        for (int i = 0; i < s1.Length; i++)
        {
            Console.Write(s1[i]);

            if (s2.IndexOf(s1[i]) > -1)
            {
                Console.Write(s1[i]);
            }
        }

        Console.WriteLine();
    }
}