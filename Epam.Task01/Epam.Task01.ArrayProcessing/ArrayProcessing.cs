using System;

public class Program
{
    public static int[] RandomArray(int n)
    {
        Random r = new Random();
        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = r.Next(-10, 11);
        }

        return a;
    }

    public static void Display(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write(a[i] + " ");
        }

        Console.WriteLine();
    }

    public static int Min(int[] a)
    {
        int min = a[0];

        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] < min)
            {
                min = a[i];
            }
        }

        return min;
    }

    public static int Max(int[] a)
    {
        int max = a[0];

        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] > max)
            {
                max = a[i];
            }
        }

        return max;
    }

    public static void Sort(int[] a)
    {
        if (a.Length == 0)
        {
            return;
        }

        Sort(a, 0, a.Length - 1);
    }

    public static void Sort(int[] a, int left, int right)
    {
        int i = left;
        int j = right;
        int x = a[(i + j) / 2];
        int y;

        do
        {
            while (a[i] < x && i < right)
            {
                i++;
            }

            while (x < a[j] && j > left)
            {
                j--;
            }

            if (i <= j)
            {
                y = a[i];
                a[i] = a[j];
                a[j] = y;
                i++;
                j--;
            }
        }
        while (i <= j);

        if (left < j)
        {
            Sort(a, left, j);
        }

        if (i < right)
        {
            Sort(a, i, right);
        }
    }

    public static void Main()
    {
        Console.WriteLine("Task 1.7. Array Processing");
        Console.WriteLine("Initial array:");
        int[] a = RandomArray(10);
        Display(a);
        Console.WriteLine("Minimum element: " + Min(a));
        Console.WriteLine("Maximum element: " + Max(a));
        Console.WriteLine("Sorted array:");
        Sort(a);
        Display(a);
    }
}