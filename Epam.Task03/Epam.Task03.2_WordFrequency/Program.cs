using System;
using System.Collections.Generic;

public class Program
{
    public static Dictionary<string, uint> WordFrequency(string input)
    {
        Dictionary<string, uint> wordFrequency = new Dictionary<string, uint>();
        string[] words = input.Split(new char[] { ' ', '.' });
        foreach (string word in words)
        {
            if (word != string.Empty)
            {
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency.Add(word, 1u);
                }
            }
        }

        return wordFrequency;
    }

    public static void Show(Dictionary<string, uint> dictionary)
    {
        if (dictionary.Count > 0)
        {
            foreach (string word in dictionary.Keys)
            {
                Console.Write($"{word}\t{dictionary[word]}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("<no words found>");
        }
    }

    public static void Main()
    {
        Console.WriteLine("Task 3.2. Word Frequency");
        Console.WriteLine("Enter the text:");
        Dictionary<string, uint> wordFrequency = WordFrequency(Console.ReadLine());
        Console.WriteLine("The word frequencies in the text are:");
        Show(wordFrequency);
    }
}