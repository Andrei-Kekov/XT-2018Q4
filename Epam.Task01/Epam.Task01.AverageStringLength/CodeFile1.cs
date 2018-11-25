using System;

class Task01_11
{
    static void Main()
    {
        Console.WriteLine("Задача 1.11. Average String Length");
        Console.WriteLine("Введите текст:");
        string s = Console.ReadLine() + ' ';

        uint words = 0;
        uint letters = 0;

        for (int i = 0; i < s.Length - 1; i++)
        {
            if (char.IsLetter(s[i]))
            {
                letters++;
                if (!char.IsLetter(s[i + 1]))
                    words++;    //конец слова
            }
        }

        Console.WriteLine("Средняя длина слова в тексте: " + (words != 0? (double) letters / words : 0));
    }
}