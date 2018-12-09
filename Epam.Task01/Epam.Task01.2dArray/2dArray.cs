using System;

public class Program
{
    public static int[,] Random2dArray(int x, int y)
    {
        Random r = new Random();
        int[,] a = new int[x, y];
        int i;
        int j;
        
        for (i = 0; i < x; i++)
        {
            for (j = 0; j < y; j++)
            {
                a[i, j] = r.Next(-10, 11);
            }
        }

        return a;
    }

    public static void Display(int[,] a)
    {
        int i;
        int j;

        for (i = 0; i <= a.GetUpperBound(0); i++)
        {
            for (j = 0; j <= a.GetUpperBound(1); j++)
            {
                Console.Write(a[i, j] + "\t");
            }

            Console.WriteLine();
        }
    }

    public static int SumOfEvenPositions(int[,] a)
    {
        int i;
        int j;
        int s = 0;

        for (i = 0; i <= a.GetUpperBound(0); i++)
        {
            for (j = i % 2; j <= a.GetUpperBound(1); j += 2)
            {
                s += a[i, j];
            }
        }

        return s;
    }

    public static void Main()
    {
        Console.WriteLine("Task 1.10. 2D Array");
        Console.WriteLine();
        Console.WriteLine("Initial array:");
        int[,] a = Random2dArray(4, 4);
        Display(a);
        Console.WriteLine();

        Console.WriteLine($"The sum of the elements in 'even' positions is {SumOfEvenPositions(a)}");
    }
}