using System;

class Task01_9
{
    static int[] RandomArray()
    {
        Random r = new Random();
        int[] Array = new int[10];
        for (int i = 0; i < 10; i++)
            Array[i] = r.Next(19) - 9;
        return Array;
    }

    static void Display(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
            Console.Write(a[i] + "; ");
        Console.WriteLine();
    }

    static void Main()
    {
        int[] a = RandomArray();

        Console.WriteLine("Задача 1.9. Non-Negative Sum");
        Console.WriteLine("Исходный массив:");
        Display(a);

        int s = 0;
        foreach (int x in a)
            if (x > 0)
                s += x;

        Console.WriteLine("Сумма неотрицательных элементов массива равна " + s);
    }
}