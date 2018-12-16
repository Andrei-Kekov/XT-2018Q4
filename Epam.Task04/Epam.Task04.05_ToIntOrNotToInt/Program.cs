using System;

public static class StringExtension
{
    public static void Main()
    {
        Console.WriteLine("Task 4.5. To Int or not to Int");
        Console.WriteLine("Enter a string:");

        if (IsNatural(Console.ReadLine()))
        {
            Console.WriteLine("This is a positive integer.");
        }
        else
        {
            Console.WriteLine("This is not a positive integer.");
        }
    }

    public static bool IsNatural(this string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return false;
        }

        int i = 0;

        if (s[i] == '+')
        {
            i++;
        }

        string intPart = ReadDigits(s, i, out i);

        if (string.IsNullOrEmpty(intPart))
        {
            return false;
        }

        string fracPart = string.Empty;

        if (i < s.Length && (s[i] == '.' || s[i] == ','))
        {
            i++;
            fracPart = ReadDigits(s, i, out i);

            if (string.IsNullOrEmpty(fracPart))
            {
                return false;
            }
        }

        string exponentString = string.Empty;
        int exponentSign = 1;

        if (i < s.Length && (s[i] == 'E' || s[i] == 'e'))
        {
            i++;

            if (i < s.Length && s[i] == '+')
            {
                i++;
            }

            if (i < s.Length && s[i] == '-')
            {
                i++;
                exponentSign = -1;
            }

            exponentString = ReadDigits(s, i, out i);

            if (string.IsNullOrEmpty(exponentString))
            {
                return false;
            }
        }

        if (i < s.Length)
        {
            return false;
        }

        int exponent = exponentSign * ParseExponent(exponentString);

        int? lastSignificant = LastSignificant(intPart, fracPart);

        return lastSignificant.HasValue && lastSignificant + exponent >= 0;
    }

    private static string ReadDigits(string s, int start, out int end)
    {
        end = start;

        if (s == null)
        {
            return string.Empty;
        }        

        while (end < s.Length && char.IsDigit(s, end))
        {
            end++;
        }

        return s.Substring(start, end - start);
    }

    private static int ParseDigit(char digit)
    {
        if (digit.CompareTo('0') >= 0 || digit.CompareTo('9') <= 0)
        {
            return (int)digit - 48;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    private static int ParseExponent(string exponentString)
    {
        int exponent = 0;

        for (int i = 0; i < exponentString.Length; i++)
        {
            exponent += ParseDigit(exponentString[i]) * TenTo(exponentString.Length - i - 1);
        }

        return exponent;
    }

    private static int TenTo(int x)
    {
        if (x < 0)
        {
            throw new ArgumentException();
        }

        int y = 1;

        for (int i = 1; i <= x; i++)
        {
            y *= 10;
        }

        return y;
    }

    private static int? LastSignificant(string intPart, string fracPart)
    {
        int i;

        for (i = fracPart.Length - 1; i >= 0; i--)
        {
            if (!char.IsDigit(fracPart[i]))
            {
                throw new ArgumentException();
            }

            if (fracPart[i] != '0')
            {
                return -i - 1;
            }
        }

        for (i = intPart.Length - 1; i >= 0; i--)
        {
            if (!char.IsDigit(intPart[i]))
            {
                throw new ArgumentException();
            }

            if (intPart[i] != '0')
            {
                return intPart.Length - i - 1;
            }
        }

        return null;
    }     
}