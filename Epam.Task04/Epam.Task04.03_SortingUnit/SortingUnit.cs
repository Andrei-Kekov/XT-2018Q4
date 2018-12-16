using System;
using System.Threading;

public class SortingUnit
{
    public delegate int Comparison<T>(T x, T y);

    public delegate void Sort<T>(T[] a, Comparison<T> compare);

    public event EventHandler SortFinished;       

    public static void Quicksort<T>(T[] a, Comparison<T> compare)
    {
        Quicksort(a, 0, a.Length - 1, compare);
    }    

    public virtual void SortInNewThread<T>(T[] a, Comparison<T> compare)
    {
        (new Thread(() => Quicksort<T>(a, compare))).Start();
        if (this.SortFinished != null)
        {
            this.SortFinished(this, EventArgs.Empty);
        }
    }

    private static void Quicksort<T>(T[] a, int left, int right, Comparison<T> compare)
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
            Quicksort(a, left, j, compare);
        }

        if (i < right)
        {
            Quicksort(a, i, right, compare);
        }
    }
}