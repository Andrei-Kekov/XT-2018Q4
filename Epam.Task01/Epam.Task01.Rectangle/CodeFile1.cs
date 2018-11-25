using System;

class Task01_1
{
    static void Main()
    {
        Console.WriteLine("Задача 1.1. Rectangle");
        Console.WriteLine("Введите стороны прямоугольника.");

        Console.Write("a: ");
        double a;
        if (!double.TryParse(Console.ReadLine(), out a) || a <= 0.0)
        {
            Console.WriteLine("Некорректное значение.");
            return;
        }

        Console.Write("b: ");
        double b;
        if (!double.TryParse(Console.ReadLine(), out b) || b <= 0.0)
        {
            Console.WriteLine("Некорректное значение.");
            return;
        }

        Console.WriteLine("Площадь прямоугольника равна " + (a * b));
    }
}