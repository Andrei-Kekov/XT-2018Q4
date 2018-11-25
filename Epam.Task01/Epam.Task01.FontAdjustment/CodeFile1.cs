using System;

class Task01_6
{
    [Flags]
    enum Font : byte
    {
        None = 0,
        Bold = 1,
        Italic = 2,
        Underline = 4,
    }

    static void Main()
    {
        int key = 0;
        Font Current = Font.None;
        int i;
        while(true)
            {
                Console.WriteLine("Параметры надписи: " + Current);
                Console.WriteLine("Введите:");
                for (i = 1; i <= 3; i++)
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