using System;

public class Program
{
    [Flags]
    public enum Font : byte
    {
        None = 0,
        Bold = 1,
        Italic = 2,
        Underline = 4,
    }

    public static void Main()
    {
        Console.WriteLine("Task 1.6. Font Adjustment");
        Font current = Font.None;
        int key;

        while (true)
        {
            Console.WriteLine("Параметры надписи: " + current);
            Console.WriteLine("Введите:");

            for (key = 1; key <= 3; key++)
            {
                Console.WriteLine("\t" + key + ": " + (Font)Math.Pow(2.0, key - 1));
            }

            if (int.TryParse(Console.ReadLine(), out key) && key >= 1 && key <= 3)
            {
                current ^= (Font)Math.Pow(2.0, key - 1);
            }
            else
            {
                Console.WriteLine("Некорректное значение.");
                break;
            }
        }
    }
}