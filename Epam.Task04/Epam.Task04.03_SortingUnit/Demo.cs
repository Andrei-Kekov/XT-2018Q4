using System;

public class Program
{
    public static int[] RandomArray(int n, Random r)
    {
        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = r.Next(-10, 11);
        }

        return a;
    }

    public static void Show(int[] a)
    {
        foreach (int i in a)
        {
            Console.Write($"{i};");
        }

        Console.WriteLine();
    }

    public static void Done(object sender, EventArgs e)
    {
        Console.WriteLine("Sort complete.");
    }

    public static void Main()
    {
        Console.WriteLine("Task 4.3. Sorting Unit");
        Console.WriteLine("Initial arrays:");
        Random r = new Random();
        int[][] a = new int[3][];
        int i;
        SortingUnit sortingUnit = new SortingUnit();
        SortingUnit.Comparison<int> compareInt = (x, y) => x - y;

        for (i = 0; i < a.Length; i++)
        {
            a[i] = RandomArray(10, r);
            Show(a[i]);
        }

        sortingUnit.SortFinished += Done;

        for (i = 0; i < a.Length; i++)
        {
            sortingUnit.SortInNewThread<int>(a[i], compareInt);
        }

        foreach (int[] ai in a)
        {
            Show(ai);
        }
    }
}