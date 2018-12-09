using System;

public class Program
{
    public static double WordLength(string s)
    {
        s += " ";
        uint words = 0;
        uint letters = 0;

        for (int i = 0; i < s.Length - 1; i++)
        {
            if (char.IsLetter(s[i]))
            {
                letters++;

                if (!char.IsLetter(s[i + 1]))
                {
                    words++;
                }
            }
        }

        return words != 0 ? (double)letters / words : 0;
    }

    public static void Main()
    {
        Console.WriteLine("Task 1.11. Average String Length");
        Console.WriteLine("Enter the text:");
        string s = Console.ReadLine();
        Console.WriteLine($"The average word length is {WordLength(s)} letters.");
    }
}