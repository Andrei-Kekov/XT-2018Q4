using System;

public class Task02_3
{
    private static void Main()
    {
        Console.WriteLine("Task 2.3. User");
        User user = new User();

        Console.Write("Enter your first name: ");
        user.FirstName = Console.ReadLine();

        Console.Write("Enter your patronymic: ");
        user.Patronymic = Console.ReadLine();

        Console.Write("Enter your last name: ");
        user.LastName = Console.ReadLine();

        Console.Write("Enter your date of birth: ");
        DateTime dateOfBirth;

        if (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
        {
            Console.WriteLine("Incorrect value");
            return;
        }

        try
        {
            user.DateOfBirth = dateOfBirth;
            Console.WriteLine("Your age is " + user.Age + " years.");
        }
        catch (ArgumentException exc)
        {
            Console.WriteLine(exc.Message);
        }        
    }
}