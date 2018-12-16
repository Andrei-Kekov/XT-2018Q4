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

    public static void Show<T>(T[] array)
    {
        foreach (T t in array)
        {
            Console.Write($"{t}; ");
        }

        Console.WriteLine();
    }

    public static int[] RandomIntArray(int n)
    {
        int[] a = new int[n];
        Random r = new Random();
        
        for (int i = 0; i < n; i++)
        {
            a[i] = r.Next(-100, 101);
        }

        return a;
    }

    public static bool[] RandomBoolArray(int n)
    {
        bool[] a = new bool[n];
        Random r = new Random();

        for (int i = 0; i < n; i++)
        {
            a[i] = r.Next(2) > 0;
        }

        return a;
    }
    
    public static void Main()
    {
        const int DEMO_SIZE = 10;
        Console.WriteLine("Task 4.1. Custom Sort");
        Comparison<bool> compareBool = (x, y) => (x == y) ? 0 : (x ? 1 : -1);
        Comparison<int> compareInt = (x, y) => x - y;
        Comparison<int> compareIntByParity = (x, y) => Math.Abs(x % 2) - Math.Abs(y % 2);
        Comparison<int> compareIntByLastDigit = (x, y) => Math.Abs(x % 10) - Math.Abs(y % 10);
        Comparison<string> compareStringLength = (x, y) => x.Length - y.Length;
        bool[] boolArray = RandomBoolArray(DEMO_SIZE);
        int[] intArray = RandomIntArray(DEMO_SIZE);
        Console.WriteLine("Initial int array:");
        Show(intArray);
        Console.WriteLine("int array sorted by value:");
        Sort(intArray, compareInt);
        Show(intArray);
        Console.WriteLine("int array sorted by parity:");
        Sort(intArray, compareIntByParity);
        Show(intArray);
        Console.WriteLine("int array sorted by last digit:");
        Sort(intArray, compareIntByLastDigit);
        Show(intArray);
        Console.WriteLine("Initial bool array:");
        Show(boolArray);
        Console.WriteLine("Sorted bool array:");
        Sort(boolArray, compareBool);
        Show(boolArray);
    }
}