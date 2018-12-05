using System;

public class Task02_5
{
    private static void Main()
    {
        Console.WriteLine("Task 2.5. Employee");
        Employee employee = new Employee();

        Console.Write("Enter your first name: ");
        employee.FirstName = Console.ReadLine();

        Console.Write("Enter your patronymic: ");
        employee.Patronymic = Console.ReadLine();

        Console.Write("Enter your last name: ");
        employee.LastName = Console.ReadLine();

        Console.Write("Enter your date of birth: ");
        DateTime dateOfBirth;

        if (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
        {
            Console.WriteLine("Incorrect value");
            return;
        }

        Console.WriteLine("Enter your appointment: ");
        employee.Appointment = Console.ReadLine();
        Console.Write("Enter your working experience (in years): ");
        int experience;

        if (!int.TryParse(Console.ReadLine(), out experience))
        {
            Console.WriteLine("Incorrect value");
            return;
        }

        try
        {
            employee.DateOfBirth = dateOfBirth;
            employee.Experience = experience;
            Console.WriteLine($"Your age is {employee.Age} years. You have been working as a {employee.Appointment} for {experience} years.");
        }
        catch (ArgumentException exc)
        {
            Console.WriteLine(exc.Message);
        }
    }
}