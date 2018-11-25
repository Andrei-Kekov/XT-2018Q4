using System;

class Task01_7
{
    static int[] RandomArray()
    {
        Random r = new Random();
        int[] a = new int[10];
        for (int i = 0; i < 10; i++)
            a[i] = r.Next(19) - 9;
        return a;
    }

    static void Main()
    {
        int[] a = RandomArray();
        int i;
        int j;
        int min = a[0];
        int max = a[0];

        Console.WriteLine("Задача 1.7. Array Processing");
        Console.WriteLine("Исходный массив:");
        for (i = 0; i < 10; i++)
        {
            Console.Write(a[i] + "; ");
            if (a[i] < min)
                min = a[i];
            if (a[i] > max)
                max = a[i];
        }
        Console.WriteLine();

        Console.WriteLine("Наименьший элемент: " + min);
        Console.WriteLine("Наибольший элемент: " + max);

        int t;
        for (i = 0; i < 10; i++)
            for (j = 0; j < 9; j++)
                if (a[j] > a[j + 1])
                {
                    t = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = t;
                }

        Console.WriteLine("Массив после сортировки:");
        for (i = 0; i < 10; i++)
        {
            Console.Write(a[i] + "; ");
        }
        Console.WriteLine();
    }
}