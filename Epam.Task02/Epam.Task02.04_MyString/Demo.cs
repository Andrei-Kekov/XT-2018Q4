using System;

public class Task02_04
{
    public static void Main()
    {
        Console.WriteLine("Task 2.4. My String");
        Console.WriteLine("Creating empty MyString...");
        MyString empty_ms = new MyString();
        Console.WriteLine("empty_ms = \"" + empty_ms + '"');
        Console.WriteLine("Creating MyString from a char...");
        MyString ms_from_char = new MyString('!');
        Console.WriteLine("ms_from_char = \"" + ms_from_char + '"');
        Console.WriteLine("Creating MyString from a char array...");
        char[] ca = { '!', '?' };
        MyString ms_from_array = new MyString(ca);
        Console.WriteLine("ms_from_array = \"" + ms_from_array + '"');
        Console.WriteLine("Creating MyString from a string...");
        MyString ms_from_string = new MyString("Hello");
        Console.WriteLine("ms_from_string = \"" + ms_from_string + '"');
        Console.WriteLine("Concatenating MyString objects...");
        Console.WriteLine("ms_from_string + ms_from_array = \"" + (ms_from_string + ms_from_array) + '"');
        Console.WriteLine("Finding a character in a MyString...");
        Console.WriteLine("The position of 'o' character in ms_from_string is " + ms_from_string.Find('o'));
    }
}