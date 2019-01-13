using System;
using System.Text.RegularExpressions;

public class Program
{
    public static MatchCollection EmailFinder(string text)
    {
        Regex email = new Regex(@"[a-z0-9]+([_\.\-][a-z0-9]+)*@[a-z0-9]+([\.\-][a-z0-9]+)*\.[a-z]{2,6}", RegexOptions.IgnoreCase);
        return email.Matches(text);
    }

    public static void Main()
    {
        Console.WriteLine("Task 7.3. Email Finder");
        Console.WriteLine("Please enter the text:");
        string text = Console.ReadLine();
        MatchCollection matches = EmailFinder(text);

        if (matches.Count > 0)
        {
            Console.WriteLine("This text contains following email addresses:");

            foreach (Match m in matches)
            {
                Console.WriteLine(m.Value);
            }
        }
        else
        {
            Console.WriteLine("This text doesn't contain any email adsresses.");
        }
    }
}