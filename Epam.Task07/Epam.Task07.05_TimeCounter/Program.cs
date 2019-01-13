using System;
using System.Text.RegularExpressions;

public class Program
{
    public static int TimeCounter(string text)
    {
        Regex time = new Regex(@"\b(([01]?[0-9])|(2[0-3])):[0-5][0-9]\b");
        return time.Matches(text).Count;
    }

    public static void Main()
    {
        Console.WriteLine("Task 7.5. Time Counter");
        Console.WriteLine("Please enter the text:");
        Console.WriteLine($"There are {TimeCounter(Console.ReadLine())} time(s) in this text.");
    }
}
