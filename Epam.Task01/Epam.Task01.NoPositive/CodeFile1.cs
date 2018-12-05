using System;

public class Task01_8
{
    public static int[,,] Random3dArray()
    {
        Random r = new Random();
        int[,,] a = new int[3, 3, 3];
        int i, j, k;
        for (i = 0; i < 3; i++)
            for (j = 0; j < 3; j++)
                for (k = 0; k < 3; k++)
                    a[i, j, k] = r.Next(19) - 9;
        return a;
    }

    public static void Display(int[,,] a)
    {
        int i, j, k;
        for (i = 0; i < 3; i++)
        {
            for (j = 0; j < 3; j++)
            {
                for (k = 0; k < 3; k++)
                    Console.Write(a[i, j, k] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    public static void Main()
    {
        int[,,] a = Random3dArray();
        int i, j, k;

        Console.WriteLine("Задача 1.8. No Positive");
        Console.WriteLine("Исходный массив:");
        Display(a);

        for (i = 0; i < 3; i++)
            for (j = 0; j < 3; j++)
                for (k = 0; k < 3; k++)
                    if (a[i, j, k] > 0)
                        a[i, j, k] = 0;

        Console.WriteLine("Полученный массив:");
        Display(a);
    }
}