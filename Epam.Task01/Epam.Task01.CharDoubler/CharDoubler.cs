using System;
using System.Text;

public class Program
{
    public static string CharDoubler(string s1, string s2)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < s1.Length; i++)
        {
            sb.Append(s1[i], s2.IndexOf(s1[i]) > -1 ? 2 : 1);
        }

        return sb.ToString();
    }

    public static void Main()
    {
        Console.WriteLine("Task 1.12. Char Doubler");
        Console.Write("Enter the first string: ");
        string s1 = Console.ReadLine();
        Console.Write("Enter the second string: ");
        string s2 = Console.ReadLine();
        Console.WriteLine($"The resulting string is: {CharDoubler(s1, s2)}");
    }
}