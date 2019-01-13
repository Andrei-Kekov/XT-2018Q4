using System;
using System.Text.RegularExpressions;

public class Program
{
    public enum Notation : byte
    {
        Unknown = 0,
        Decimal = 1,
        Scientific = 2
    }

    public static Notation NumberValidator(string number)
    {
        Regex decimalNotation = new Regex(@"^[+-]?[0-9]+([\.,][0-9]+)?$");
        Regex scientificNotatoin = new Regex(@"^[+-]?[0-9]+([\.,][0-9]+)?[Ee][+-]?[0-9]+$");

        if (decimalNotation.IsMatch(number))
        {
            return Notation.Decimal;
        }

        if (scientificNotatoin.IsMatch(number))
        {
            return Notation.Scientific;
        }

        return Notation.Unknown;
    }

    public static void Main()
    {
        Console.WriteLine("Task 7.4. Number Validator");
        Console.WriteLine("Please enter a number:");

        switch (NumberValidator(Console.ReadLine()))
        {
            case Notation.Decimal:
                Console.WriteLine("This is a number in decimal notation.");
                break;
            case Notation.Scientific:
                Console.WriteLine("This is a number in scientific notation.");
                break;
            default:
                Console.WriteLine("This is not a number in decimal or scientific notatipn.");
                break;
        }
    }
}
