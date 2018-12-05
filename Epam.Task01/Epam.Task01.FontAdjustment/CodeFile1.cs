using System;

class Task01_6
{
    [Flags]
    enum Font : byte
    {
        None = 0b000,
        Bold = 0b001,
        Italic = 0b010,
        Underline = 0b100,
    }

    static void Main()
    {
        Font Current = Font.None;
        int key;
        while (true)
            {
                Console.WriteLine("Параметры надписи: " + Current);
                Console.WriteLine("Введите:");
                for (int i = 1; i <= 3; i++)
                    Console.WriteLine("\t" + i + ": " + (Font)Math.Pow(2.0, i - 1));
                if(int.TryParse(Console.ReadLine(), out key) && key >= 1 && key <= 3)
                    Current ^= (Font)Math.Pow(2.0, key - 1);
                else
                {
                Console.WriteLine("Некорректное значение.");
                break;
                }
            }
    }
}