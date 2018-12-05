using System;

public class Task01_6
{
    [Flags]
    public enum Font : byte
    {
        None = 0b000,
        Bold = 0b001,
        Italic = 0b010,
        Underline = 0b100,
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