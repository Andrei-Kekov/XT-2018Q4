using System;

public class Program
{
    public delegate int Comparison<T>(T x, T y);

    public static void Sort<T>(T[] a, Comparison<T> compare)
    {
        Sort(a, 0, a.Length - 1, compare);
    }

    public static void Sort<T>(T[] a, int left, int right, Comparison<T> compare)
    {
        int i = left;
        int j = right;
        T x = a[(i + j) / 2];
        T y;

        do
        {
            while (compare(a[i], x) < 0 && i < right)
            {
                i++;
            }

            while (compare(x, a[j]) < 0 && j > left)
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
            Sort(a, left, j, compare);
        }

        if (i < right)
        {
            Sort(a, i, right, compare);
        }
    }

    public static void Show(string[] array)
    {
        foreach (string s in array)
        {
            Console.WriteLine(s);
        }
    }

    public static int CompareStrings(string s1, string s2)
    {
        if (s1.Length != s2.Length)
        {
            return s1.Length - s2.Length;
        }
        else
        {
            return s1.CompareTo(s2);
        }
    }

    public static void Main()
    {
        Console.WriteLine("Task 4.2. Custom Sort Demo");
        Console.WriteLine("Enter five strings:");
        string[] s = new string[5];

        for (int i = 0; i < s.Length; i++)
        {
            s[i] = Console.ReadLine();
        }

        Sort(s, CompareStrings);
        Console.WriteLine("Sorted strings:");
        Show(s);
    }
}