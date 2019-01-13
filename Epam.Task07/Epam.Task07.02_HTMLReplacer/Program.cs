using System;
using System.Text.RegularExpressions;

public class Program
{
    public static string HTMLReplacer(string text)
    {
        Regex tag = new Regex("<.*?>");
        return tag.Replace(text, "_");
    }

    public static void Main()
    {
        Console.WriteLine("Task 7.2. HTML Replacer");
        Console.WriteLine("Please enter the text:");
        Console.WriteLine(HTMLReplacer(Console.ReadLine()));
    }
}