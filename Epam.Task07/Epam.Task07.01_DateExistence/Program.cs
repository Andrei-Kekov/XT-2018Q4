using System;
using System.Text.RegularExpressions;

public class Program
{
    public static bool DateExistence(string text)
    {
        Regex month31DaysLong = new Regex("((0[1-9])|([12][0-9])|(3[01]))-((0[13578])|(1[02]))-[0-9]{4}");
        Regex month30DaysLong = new Regex("((0[1-9])|([12][0-9])|(30))-((0[469])|(11))-[0-9]{4}");
        Regex leapYearFebruary = new Regex("((0[1-9])|([12][0-9]))-02-(([0-9]{2}((0[468])|([2468][048])|([13579][26])))|(([02468][048])|([13579][26])00))");
        Regex commonYearFebruary = new Regex("((0[1-9])|([12][0-8]))-02-[0-9]{2}(([02468][1235679])|([13579][01345789]))");
        return month31DaysLong.IsMatch(text) || month30DaysLong.IsMatch(text) || commonYearFebruary.IsMatch(text) || leapYearFebruary.IsMatch(text);
    }

    public static void Main()
    {
        Console.WriteLine("Task 7.1. Date Existence");
        Console.WriteLine("Please enter the text:");

        if (DateExistence(Console.ReadLine()))
        {
            Console.WriteLine("This text contains a dd-mm-yyyy date.");
        }
        else
        {
            Console.WriteLine("This text doesn't contain any valid dd-mm-yyyy dates.");
        }
    }
}