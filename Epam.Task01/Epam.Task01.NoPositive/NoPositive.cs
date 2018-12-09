using System;

public class Program
{
    public static int[,,] Random3dArray(int x, int y, int z)
    {
        Random r = new Random();
        int[,,] a = new int[x, y, z];
        int i, j, k;

        for (i = 0; i < x; i++)
        {
            for (j = 0; j < y; j++)
            {
                for (k = 0; k < z; k++)
                {
                    a[i, j, k] = r.Next(-10, 11);
                }
            }
        }

        return a;
    }

    public static void Display(int[,,] a)
    {
        int i, j, k;

        for (i = 0; i < a.GetLength(0); i++)
        {
            for (j = 0; j < a.GetLength(1); j++)
            {
                for (k = 0; k < a.GetLength(2); k++)
                {
                    Console.Write(a[i, j, k] + "\t");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }

    public static int[,,] NoPositive(int[,,] a)
    {
        int i, j, k;

        for (i = 0; i < a.GetLength(0); i++)
        {
            for (j = 0; j < a.GetLength(1); j++)
            {
                for (k = 0; k < a.GetLength(2); k++)
                {
                    if (a[i, j, k] > 0)
                    {
                        a[i, j, k] = 0;
                    }
                }
            }
        }

        return a;
    }

    public static void Main()
    {
        Console.WriteLine("Task 1.8. No Positive");
        Console.WriteLine("Initial array:");
        int[,,] a = Random3dArray(3, 3, 3);
        Display(a);
        Console.WriteLine("Resulting array:");
        Display(NoPositive(a));
    }
}