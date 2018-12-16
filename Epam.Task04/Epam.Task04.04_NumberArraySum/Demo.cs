using System;

public class Demo
{
    public static void Show<T>(T[] a)
    {
        foreach (T t in a)
        {
            Console.Write($"{t}; ");
        }

        Console.WriteLine();
    }

    public static void Main()
    {
        Console.WriteLine("Task 4.4. NumberArraySum");
        byte[] byteArray = { 0, 2, 8, 1 };
        ushort[] ushortArray = { 16, 12, 2, 2 };
        long[] longArray = { 999999999L, -999999999L, 12, -2 };
        double[] doubleArray = { 2.16e-4, -1.18e-4, 5, 9.9e-4 };
        decimal[] decimalArray = { 1858.5546m, 1995.0008m, -4009.9998m };
        Console.WriteLine();
        Console.WriteLine("byte array:");
        Show(byteArray);
        Console.WriteLine($"byte array sum: {byteArray.Sum()}");
        Console.WriteLine();
        Console.WriteLine("ushort array:");
        Show(ushortArray);
        Console.WriteLine($"ushort array sum: {ushortArray.Sum()}");
        Console.WriteLine();
        Console.WriteLine("long array:");
        Show(longArray);
        Console.WriteLine($"long array sum: {longArray.Sum()}");
        Console.WriteLine();
        Console.WriteLine("double array:");
        Show(doubleArray);
        Console.WriteLine($"double array sum: {doubleArray.Sum()}");
        Console.WriteLine();
        Console.WriteLine("decimal array:");
        Show(decimalArray);
        Console.WriteLine($"decimal array sum: {decimalArray.Sum()}");
    }
}