using System;

class Task01_10
{
    static int[,] Random2dArray()
    {
        Random r = new Random();
        int[,] a = new int[4, 4];
        int i, j;
        for (i = 0; i < 4; i++)
            for (j = 0; j < 4; j++)
                    a[i, j] = r.Next(19) - 9;
        return a;
    }

    static void Display(int[,] a)
    {
        int i, j;
        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
                Console.Write(a[i, j] + "\t");
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int[,] a = Random2dArray();

        Console.WriteLine("Задача 1.10. 2D Array");
        Console.WriteLine("Исходный массив:");
        Display(a);
        Console.WriteLine();

        int i, j;
        int s = 0;
        for (i = 0; i < 4; i++)
            for (j = i % 2; j < 4; j += 2)
                s += a[i, j];

        Console.WriteLine("Сумма элементов, стоящих на \"чётных\" местах: " + s);
    }
}